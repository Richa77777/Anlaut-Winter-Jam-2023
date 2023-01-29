using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade1 : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Dark()
    {
        _animator.Play("FadeDark", -1, 0f);
    }

    public void Transparent()
    {
        _animator.Play("FadeTransparent", -1, 0f);
    }

    public void OffObject()
    {
        gameObject.SetActive(false);
    }

    public void OnObject()
    {
        gameObject.SetActive(true);
    }
}
