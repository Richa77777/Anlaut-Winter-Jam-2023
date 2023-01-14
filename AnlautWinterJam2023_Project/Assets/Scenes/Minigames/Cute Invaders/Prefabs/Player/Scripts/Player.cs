using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
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
        }

        #region Move

        private Vector3 refVel = Vector3.zero;

        [Header("MoveVariables")]
        [SerializeField] private float smoothValue = .2f;
        [Range(0f, 5f)]
        [SerializeField] private float _moveSpeed = 0f;

        private void Move()
        {
            float horizontalAxis = Input.GetAxis("Horizontal");

            _rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, new Vector3(horizontalAxis * _moveSpeed, 0f, 0f), ref refVel, smoothValue);
        }

        private void StopMove()
        {

            _rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, Vector3.zero, ref refVel, smoothValue);
        }

        #endregion

        #region Shoot
        
        [Space(10f)]

        [Header("ShootVariables")]
        [Range(0, 10)] [SerializeField] private int _bulletsPoolSize;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletsParent; // Место, куда будут складываться пули.
        [SerializeField] private GameObject _bulletSpawnpoint;

        private List<GameObject> _bulletsPool = new List<GameObject>();

        private void Shoot()
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
        }

        #endregion
    }
}