using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders.Enemies
{
    public class Doggy : Enemy
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

                for (int i = 0; i < _enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Doggy).Count; i++)
                {
                    if (_enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Doggy)[i].activeInHierarchy == false)
                    {
                        _enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Doggy)[i].SetActive(true);
                        _enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Doggy)[i].transform.position = _bulletsSpawnpoint.transform.position;
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
                if (_enemyController.EnemiesGet[i].GetComponent<Doggy>())
                {
                    value += _groupDependency;
                }
            }

            return value;
        }
    }
}