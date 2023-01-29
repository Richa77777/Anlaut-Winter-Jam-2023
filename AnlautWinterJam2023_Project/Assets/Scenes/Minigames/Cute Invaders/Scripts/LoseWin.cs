using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseWin : MonoBehaviour
{
    [SerializeField] private Button _winButton;
    [SerializeField] private Button _loseButton;


    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win()
    {
        _winButton.gameObject.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Lose()
    {
        _loseButton.gameObject.SetActive(true);
        Time.timeScale = 0f;

    }
}
