using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CuteInvaders;

public class LoadSceneByName : MonoBehaviour
{
    [SerializeField] private Fade1 _fade;

    private static LoadSceneByName _instance;

    public static LoadSceneByName Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _fade.Transparent();
    }

    public void ChangeMinigame(string sceneName)
    {
        StartCoroutine(ChangeMinigameI(sceneName));
    }

    private IEnumerator ChangeMinigameI(string sceneName)
    {
        _fade.gameObject.SetActive(true);
        _fade.Dark();

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }
}