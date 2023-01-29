using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPlayerPrefs : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteKey("currentProgress");
        //PlayerPrefs.SetFloat("currentProgress", 0f);
        PlayerPrefs.DeleteAll();
    }
}
