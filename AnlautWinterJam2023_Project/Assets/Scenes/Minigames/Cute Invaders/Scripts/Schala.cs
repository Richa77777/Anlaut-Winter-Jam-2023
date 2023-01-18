using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CuteInvaders.Enemies;

public class Schala : MonoBehaviour
{
    [SerializeField] private Image _schala;
    public float _percentForOne;
    [SerializeField] public float _biggerPercentSchala;

    private LoseWin _loseWin;

    private EnemyController _enemyController;

    private void Start()
    {
        _enemyController = FindObjectOfType<EnemyController>();
        _loseWin = FindObjectOfType<LoseWin>();
    }

    public void AddSchala()
    {
        _schala.fillAmount += 0.06666666666f;

        if (_schala.fillAmount == 1)
        {
            _loseWin.Win();
        }
    }



}
