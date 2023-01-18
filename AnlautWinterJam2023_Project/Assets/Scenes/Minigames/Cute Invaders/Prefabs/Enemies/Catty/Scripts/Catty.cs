using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders.Enemies
{
    public class Catty : Enemy
    {
        private void Start()
        {
            StartCoroutine(Shoot());
        }

        public override IEnumerator Shoot()
        {
            while (true)
            {
                yield return new WaitForSeconds(_shootCooldown - GeneralGroupDependency());
                
                for (int i = 0; i < _enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Catty).Count; i++)
                {
                    if (_enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Catty)[i].activeInHierarchy == false)
                    {
                        _enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Catty)[i].SetActive(true);
                        _enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Catty)[i].transform.position = _bulletsSpawnpoint.transform.position;
                        break;
                    }

                    yield return null;
                }

                yield return null;
            }
        }

        protected override float GeneralGroupDependency()
        {
            float value = 0f;

            for (int i = 0; i < _enemyController.EnemiesGet.Count; i++)
            {
                if (_enemyController.EnemiesGet[i].GetComponent<Catty>())
                {
                    value += _groupDependency;
                }
            }

            return value;
        }
    }
}