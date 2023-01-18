using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CuteInvaders.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {

        protected Rigidbody2D _rigidbody;
        protected EnemyController _enemyController;
        protected EnemyPools _enemyPools;
        private Schala _schala;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _enemyController = FindObjectOfType<EnemyController>();
            _enemyPools = FindObjectOfType<EnemyPools>();
            _currentHp = _startHp;
            _schala = FindObjectOfType<Schala>();
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
                _schala.AddSchala();
            }
        }

        #region Move

        [SerializeField] protected float _moveSpeed = 0.1f;

        protected virtual void Move()
        {
            _rigidbody.velocity = Vector2.down * _moveSpeed;
        }
        #endregion

        #region Shoot

        [Header("Shoot Variables")]
        [SerializeField] protected float _shootCooldown;
        [SerializeField] protected Transform _bulletsSpawnpoint;

        public Transform BulletSpawnpoints { get => _bulletsSpawnpoint; }

        public abstract IEnumerator Shoot();
        #endregion

        #region Dependency

        [Space(10f)]
        [Header("Dependency Variables")]
        [SerializeField] protected float _groupDependency = 0f; // Влияние/Зависимость на/от группу(ы).

        protected abstract float GeneralGroupDependency();

        #endregion

        #region HP

        [Space(10f)]
        [Header("HP Variables")]
        [SerializeField] protected const int _startHp = 0;

        protected int _currentHp;

        public int CurrentHp { get { return _currentHp; } }

        public void AddHp(int value)
        {
            _currentHp = Mathf.Clamp(_currentHp += value, 0, _startHp);
        }

        #endregion
    }
}