using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace CuteInvaders.Enemies
{
    public class PandasController : MonoBehaviour
    {
        private List<Panda> _allPandas = new List<Panda>();

        private EnemyPools _enemyPools;

        private Panda panda;


        private void Start()
        {
            _enemyPools = FindObjectOfType<EnemyPools>();

            UpdateList();
            StartCoroutine(ShootPandas());
        }

        private IEnumerator ShootPandas()
        {
            while (true)
            {
                UpdateList();

                yield return new WaitForSeconds(5 - _allPandas.Count * 0.3f);

                Panda currentPanda = null;

                List<Panda> allPandasBe = new List<Panda>();

                for (int i = 0; i < _allPandas.Count; i++)
                {
                    currentPanda = _allPandas[Random.Range(0, _allPandas.Count - 1)];

                    if (allPandasBe.Count == 0)
                    {
                        currentPanda.ShootP();
                        allPandasBe.Add(currentPanda);
                    }

                    else if (allPandasBe.Count != 0)
                    {
                        if (!allPandasBe.Contains(currentPanda))
                        {
                            currentPanda.ShootP();
                            allPandasBe.Add(currentPanda);
                        }
                    }

                    yield return null;
                }

                UpdateList();

                yield return null;
            }
        }

        public void UpdateList()
        {
            _allPandas = FindObjectsOfType<Panda>().ToList();
        }
    }
}
