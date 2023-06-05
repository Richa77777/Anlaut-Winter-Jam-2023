using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CuteInvaders;

public class LoseWin : MonoBehaviour
{
    [SerializeField] private GameObject _loseButton;
    [SerializeField] private GameObject _musicObject;
    [SerializeField] private AudioClip[] _sounds = new AudioClip[2];
    [SerializeField] private int _nextSceneIndex;

    private LoadStoryScene _loadStoryScene;
    private AudioSource _audioSource;

    private void Start()
    {
        _loadStoryScene = FindObjectOfType<LoadStoryScene>(true);
        _audioSource = GetComponent<AudioSource>();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win()
    {
        _musicObject.SetActive(false);
        _audioSource.PlayOneShot(_sounds[1]);
        _loadStoryScene.ChangeStoryScene(_nextSceneIndex);
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        _musicObject.SetActive(false);
        _audioSource.PlayOneShot(_sounds[0]);
        _loseButton.gameObject.SetActive(true);
        Time.timeScale = 0f;

    }
}
