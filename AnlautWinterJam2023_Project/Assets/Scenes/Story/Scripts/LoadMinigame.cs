using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CuteInvaders;

public class LoadMinigame : MonoBehaviour
{
    [SerializeField] private Fade _fade;

    private void Start()
    {
        _fade.Transparent();
    }

    public void ChangeMinigame(int index)
    {
        StartCoroutine(ChangeMinigameI(index));
    }

    private IEnumerator ChangeMinigameI(int index)
    {
        _fade.gameObject.SetActive(true);
        _fade.Dark();

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Level" + index);
    }
}