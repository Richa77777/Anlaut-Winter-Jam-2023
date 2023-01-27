using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private float _maxVolume = 1f;
    [SerializeField]
    private float _minVolume = 0f;

    private AudioSource _audioSource;
    private AudioClip _clip;

    [SerializeField]
    private float _fadeInDuration = 2f;
    [SerializeField]
    private float _fadeOutDuration = 2f;

    private IEnumerator _fadeIn;
    private IEnumerator _fadeOut;

    private static AudioManager _instance;

    public static AudioManager Instance { get => _instance; set => _instance = value; }
    public AudioClip Clip { get => _clip; set => _clip = value; }

    private void Awake()
    {
        if( _instance == null )
        {
            _instance = this;
        }
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartMusic()
    {
        if(_fadeOut != null)
        {
            StopCoroutine(_fadeOut);
        }

        _audioSource.clip = _clip;
        _audioSource.Play();

        _fadeIn = FadeIn(_audioSource, _fadeInDuration, _maxVolume);
        StartCoroutine(_fadeIn);
    }

    public void StopMusic()
    {
        _fadeOut = FadeOut(_audioSource, _fadeOutDuration, _minVolume);

        if(_audioSource.isPlaying)
        {
            StopCoroutine(_fadeIn);
            StartCoroutine(_fadeOut);
        }
    }

    IEnumerator FadeIn(AudioSource aSource, float duration, float targetVolume)
    {
        float timer = 0f;
        float currentVolume = aSource.volume;
        float targetValue = Mathf.Clamp(targetVolume, _minVolume, _maxVolume);

        while(timer < duration)
        {
            timer += Time.deltaTime;

            var newVolume = Mathf.Lerp(currentVolume, targetValue, timer / duration);
            aSource.volume = newVolume;

            yield return null;
        }
    }

    IEnumerator FadeOut(AudioSource aSource, float duration, float targetVolume)
    {
        float timer = 0f;
        float currentVolume = aSource.volume;
        float targetValue = Mathf.Clamp(targetVolume, _minVolume, _maxVolume);

        while (aSource.volume > 0)
        {
            timer += Time.deltaTime;

            var newVolume = Mathf.Lerp(currentVolume, targetValue, timer / duration);
            aSource.volume = newVolume;

            yield return null;
        }
    }
}
