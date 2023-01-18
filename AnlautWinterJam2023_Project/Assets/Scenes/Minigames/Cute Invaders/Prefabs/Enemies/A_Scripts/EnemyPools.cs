using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CuteInvaders.Enemies
{
    public class EnemyPools : MonoBehaviour
    {
        public enum EnemyTypes
        {
            Catty,
            Doggy,
            Panda
        }

        [System.Serializable]
        public struct Pools
        {
            [System.Serializable]
            public struct Catty
            {
                [Range(0, 30)] [SerializeField] private int _bulletsPoolSize;
                [SerializeField] private GameObject _bulletPrefab;
                [SerializeField] private Transform _bulletsParent; // Место, куда будут складываться пули.

                private List<GameObject> _bulletsPool;

                public int BulletsPoolSize { get => _bulletsPoolSize;}
                public GameObject BulletPrefab { get => _bulletPrefab; }
                public Transform BulletsParent { get => _bulletsParent; }
                public List<GameObject> BulletsPool { get => _bulletsPool; set => _bulletsPool = value; }
            }

            [System.Serializable]
            public struct Doggy
            {
                [Range(0, 30)] [SerializeField] private int _bulletsPoolSize;
                [SerializeField] private GameObject _bulletPrefab;
                [SerializeField] private Transform _bulletsParent; // Место, куда будут складываться пули.

                private List<GameObject> _bulletsPool;

                public int BulletsPoolSize { get => _bulletsPoolSize; }
                public GameObject BulletPrefab { get => _bulletPrefab; }
                public Transform BulletsParent { get => _bulletsParent; }
                public List<GameObject> BulletsPool { get => _bulletsPool; set => _bulletsPool = value; }
            }

            [System.Serializable]
            public struct Panda
            {
                [Range(0, 30)] [SerializeField] private int _bulletsPoolSize;
                [SerializeField] private GameObject _bulletPrefab;
                [SerializeField] private Transform _bulletsParent; // Место, куда будут складываться пули.

                private List<GameObject> _bulletsPool;

                public int BulletsPoolSize { get => _bulletsPoolSize; }
                public GameObject BulletPrefab { get => _bulletPrefab; }
                public Transform BulletsParent { get => _bulletsParent; }
                public List<GameObject> BulletsPool { get => _bulletsPool; set => _bulletsPool = value; }
            }

            [SerializeField] private Catty _catty;
            [SerializeField] private Doggy _doggy;
            [SerializeField] private Panda _panda;

            public void FillPool(EnemyTypes enemyType) // Добавлять врага при добавлении нового врага)))))
            {
                switch (enemyType)
                {
                    case EnemyTypes.Catty:

                        _catty.BulletsPool = new List<GameObject>();
                        
                        for (int i = 0; i < _catty.BulletsPoolSize; i++)
                        {
                            GameObject bullet = Instantiate(_catty.BulletPrefab, _catty.BulletsParent);

                            _catty.BulletsPool.Add(bullet);

                            bullet.SetActive(false);
                        }

                        break;

                    case EnemyTypes.Doggy:

                        _doggy.BulletsPool = new List<GameObject>();

                        for (int i = 0; i < _doggy.BulletsPoolSize; i++)
                        {
                            GameObject bullet = Instantiate(_doggy.BulletPrefab, _doggy.BulletsParent);

                            _doggy.BulletsPool.Add(bullet);

                            bullet.SetActive(false);
                        }

                        break;

                    case EnemyTypes.Panda:

                        _panda.BulletsPool = new List<GameObject>();

                        for (int i = 0; i < _panda.BulletsPoolSize; i++)
                        {
                            GameObject bullet = Instantiate(_panda.BulletPrefab, _panda.BulletsParent);

                            _panda.BulletsPool.Add(bullet);

                            bullet.SetActive(false);
                        }

                        break;
                }
            }

            // Во всех методах ниже добавлять новых врагов.

            public GameObject GetBulletPrefab(EnemyTypes enemyType)
            {
                GameObject value = null;

                switch (enemyType)
                {
                    case EnemyTypes.Catty:
                        value = _catty.BulletPrefab;
                        break;

                    case EnemyTypes.Doggy:
                        value = _doggy.BulletPrefab;
                        break;

                    case EnemyTypes.Panda:
                        value = _panda.BulletPrefab;
                        break;

                }

                return value;
            }

            public Transform GetBulletsParent(EnemyTypes enemyType)
            {
                Transform value = null;

                switch (enemyType)
                {
                    case EnemyTypes.Catty:
                        value = _catty.BulletsParent;
                        break;

                    case EnemyTypes.Doggy:
                        value = _doggy.BulletsParent;
                        break;

                    case EnemyTypes.Panda:
                        value = _panda.BulletsParent;
                        break;
                }

                return value;
            }

            public List<GameObject> GetBulletsPool(EnemyTypes enemyType)
            {
                List<GameObject> value = null;

                switch (enemyType)
                {
                    case EnemyTypes.Catty:
                        value = _catty.BulletsPool;
                        break;

                    case EnemyTypes.Doggy:
                        value = _doggy.BulletsPool;
                        break;

                    case EnemyTypes.Panda:
                        value = _panda.BulletsPool;
                        break;
                }

                return value;
            }
        }

        [SerializeField] private Pools _pools;

        public Pools PoolsGet { get => _pools; }


        private void Start()
        {
            _pools.FillPool(EnemyTypes.Catty); // Добавялть метод заполнения пула при добавлении врага.
            _pools.FillPool(EnemyTypes.Doggy);
            _pools.FillPool(EnemyTypes.Panda);
        }
    }
}