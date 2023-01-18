using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders.Enemies
{
    public class Panda : Enemy
    {
        public float Dep { get => GeneralGroupDependency(); } 

        public void ShootP()
        {
            StartCoroutine(Shoot());
        }

        public override IEnumerator Shoot()
        {
            for (int i = 0; i < _enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Catty).Count; i++)
            {
                if (_enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Panda)[i].activeInHierarchy == false)
                {
                    _enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Panda)[i].SetActive(true);
                    _enemyPools.PoolsGet.GetBulletsPool(EnemyPools.EnemyTypes.Panda)[i].transform.position = _bulletsSpawnpoint.transform.position;
                    break;
                }

                yield return null;
            }

            yield return null;
        }

        protected override float GeneralGroupDependency()
        {
            float value = 0f;

            for (int i = 0; i < _enemyController.EnemiesGet.Count; i++)
            {
                if (_enemyController.EnemiesGet[i].GetComponent<Panda>())
                {
                    value += _groupDependency;
                }
            }

            return value;
        }
    }
}