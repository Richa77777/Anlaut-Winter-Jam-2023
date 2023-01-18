using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private float _updatedProgress;

    [SerializeField]
    private Image _progress;
    [SerializeField]
    private float _maxProgress;

    private void Start()
    {
        _updatedProgress = PlayerPrefs.GetFloat("currentProgress");
        _progress.fillAmount = _updatedProgress/_maxProgress;
    }

    public void UpdateBarValue(float newValue)
    {
        StartCoroutine(SetValueBar(newValue));

        _updatedProgress = _progress.fillAmount * _maxProgress;
        PlayerPrefs.SetFloat("currentProgress", _updatedProgress);
    }

    IEnumerator SetValueBar(float newValue)
    {
        while (_progress.fillAmount != newValue)
        {
            _progress.fillAmount = Mathf.MoveTowards(_progress.fillAmount, newValue, 1f * Time.deltaTime);

            yield return null;
        }
    }

}
