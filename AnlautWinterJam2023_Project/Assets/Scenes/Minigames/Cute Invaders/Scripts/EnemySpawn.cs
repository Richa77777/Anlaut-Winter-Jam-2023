using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CuteInvaders.Enemies;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnpoints1 = new GameObject[5];
    [SerializeField] private GameObject[] _spawnpoints2 = new GameObject[5];
    [SerializeField] private GameObject[] _spawnpoints3 = new GameObject[5];

    [SerializeField] private List<GameObject> _lineOne = new List<GameObject>();
    [SerializeField] private List<GameObject> _lineTwo = new List<GameObject>();
    [SerializeField] private List<GameObject> _lineThree = new List<GameObject>();

    private EnemyController _enemyController;

    private void Awake()
    {
        _enemyController = FindObjectOfType<EnemyController>();

        for (int i = 0; i < _lineOne.Count; i++)
        {
            GameObject pref = Instantiate(_lineOne[i]);

            pref.transform.position = _spawnpoints1[i].transform.position;

            _enemyController.EnemiesGet.Add(pref.GetComponent<Enemy>());
        }

        for (int i = 0; i < _lineTwo.Count; i++)
        {
            GameObject pref = Instantiate(_lineTwo[i]);

            pref.transform.position = _spawnpoints2[i].transform.position;

            _enemyController.EnemiesGet.Add(pref.GetComponent<Enemy>());
        }

        for (int i = 0; i < _lineThree.Count; i++)
        {
            GameObject pref = Instantiate(_lineThree[i]);

            pref.transform.position = _spawnpoints3[i].transform.position;

            _enemyController.EnemiesGet.Add(pref.GetComponent<Enemy>());
        }

    }
}
