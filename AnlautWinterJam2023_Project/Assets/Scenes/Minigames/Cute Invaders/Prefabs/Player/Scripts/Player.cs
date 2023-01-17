using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            GameObject bullet;

            for (int i = 0; i < _bulletsPoolSize; i++)
            {
                bullet = Instantiate(_bulletPrefab, _bulletsParent);
                
                _bulletsPool.Add(bullet);

                bullet.SetActive(false);
            }
        }

        private void FixedUpdate()
        {
            if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                Move();
            }

            if (Input.GetAxisRaw("Horizontal") == 0f)
            {
                StopMove();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }

            Timer();
        }

        #region Move

        private Vector3 refVel = Vector3.zero;

        [Header("Move Variables")]
        [SerializeField] private float smoothValue = .2f;
        [Range(0f, 5f)]
        [SerializeField] private float _moveSpeed = 0f;

        private void Move()
        {
            float horizontalAxis = Input.GetAxis("Horizontal");

            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, new Vector3(horizontalAxis * _moveSpeed, 0f, 0f), ref refVel, smoothValue);
        }

        private void StopMove()
        {

            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, Vector3.zero, ref refVel, smoothValue);
        }

        #endregion

        #region Shoot
        
        [Space(10f)]

        [Header("Shoot Variables")]
        [Range(0, 10)] [SerializeField] private int _bulletsPoolSize;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletsParent; // �����, ���� ����� ������������ ����.
        [SerializeField] private GameObject _bulletSpawnpoint;

        [Range(0.0f, 10f)] [SerializeField] private float _cooldownTime = 0f;
        private float _currentCooldownTime = 0f;

        private List<GameObject> _bulletsPool = new List<GameObject>();

        private void Shoot()
        {
            if (_currentCooldownTime == 0)
            {
                for (int i = 0; i < _bulletsPoolSize; i++)
                {
                    if (_bulletsPool[i].activeInHierarchy == false)
                    {
                        _bulletsPool[i].transform.position = _bulletSpawnpoint.transform.position;
                        _bulletsPool[i].SetActive(true);
                        break;
                    }
                }

                _currentCooldownTime = _cooldownTime;
            }
        }

        private void Timer()
        {
            _currentCooldownTime = Mathf.Clamp(_currentCooldownTime - Time.deltaTime, 0f, _cooldownTime);
        }
        #endregion
    }
}