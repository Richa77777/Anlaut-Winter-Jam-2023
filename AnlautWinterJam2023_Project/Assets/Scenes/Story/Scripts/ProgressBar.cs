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

    public float UpdatedProgress { get => _updatedProgress; set => _updatedProgress = value; }
    public Image Progress { get => _progress; set => _progress = value; }

    void Update()
    {
        _progress.fillAmount = _updatedProgress / _maxProgress;
    }
}
