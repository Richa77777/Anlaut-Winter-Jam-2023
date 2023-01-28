using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CuteInvaders.Enemies;

public class Schala : MonoBehaviour
{
    [SerializeField] private Image _schala;
    private float _percentForOne;
    [SerializeField] private float _biggerPercentSchala;

    private LoseWin _loseWin;

    private EnemyController _enemyController;

    private void Start()
    {
        _enemyController = FindObjectOfType<EnemyController>();
        _loseWin = FindObjectOfType<LoseWin>();

        Invoke(nameof(Percent), 0.35f);
    }

    private void Percent()
    {
        _percentForOne = 1.0f / _enemyController.EnemiesGet.Count;
        print(_percentForOne);
    }

    public void AddSchala()
    {
        _schala.fillAmount += _percentForOne;

        if (_schala.fillAmount == 1)
        {
            _loseWin.Win();
        }
    }
}
