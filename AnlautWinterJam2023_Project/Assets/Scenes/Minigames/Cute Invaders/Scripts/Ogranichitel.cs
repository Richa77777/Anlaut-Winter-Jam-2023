using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CuteInvaders;

public class Ogranichitel : MonoBehaviour
{
    private Player _player;
    private Camera _camera;
    private LoseWin _loseWin;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _camera = Camera.main;
        _loseWin = _camera.GetComponent<LoseWin>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            _loseWin.Lose();
        }
    }
}
