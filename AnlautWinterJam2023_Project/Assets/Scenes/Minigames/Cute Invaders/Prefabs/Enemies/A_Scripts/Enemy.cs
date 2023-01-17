using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CuteInvaders.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            //_currentHp = _startHp;

            //GameObject bullet;

            //for (int i = 0; i < _bulletsPoolSize; i++)
            //{
            //    bullet = Instantiate(_bulletPrefab, _bulletsParent);

            //    _bulletsPool.Add(bullet);

            //    bullet.SetActive(false);
            //}
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerBullet"))
            {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }

        #region Move

        [SerializeField] private float _moveSpeed = 0f;

        private void Move()
        {
            _rigidbody.velocity = Vector2.down * _moveSpeed;
        }
        #endregion

        //#region Shoot

        //[Header("Shoot Variables")]
        //[Range(0, 10)] [SerializeField] private int _bulletsPoolSize;
        //[SerializeField] private GameObject _bulletPrefab;
        //[SerializeField] private Transform _bulletsParent; // Место, куда будут складываться пули.
        //[SerializeField] private GameObject _bulletSpawnpoint;

        //private List<GameObject> _bulletsPool = new List<GameObject>();

        //public void Shoot()
        //{

        //}
        //#endregion

        //#region Dependency

        //[Space(10f)]
        //[Header("Dependency Variables")]
        //[SerializeField] protected float _groupDependency = 0f; // Влияние/Зависимость на/от группу(ы).

        //protected virtual void GroupDependency()
        //{

        //}

        //#endregion

        //#region HP

        //[Space(10f)]
        //[Header("HP Variables")]
        //[SerializeField] protected const int _startHp = 0;

        //protected int _currentHp;

        //public int CurrentHp { get { return _currentHp; } }

        //public void AddHp(int value)
        //{
        //    _currentHp = Mathf.Clamp(_currentHp += value, 0, _startHp);
        //}

        //#endregion
    }
}