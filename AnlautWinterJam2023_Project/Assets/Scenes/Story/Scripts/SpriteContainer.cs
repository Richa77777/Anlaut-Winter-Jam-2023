using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteContainer : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _images = new List<Sprite>();

    public List<Sprite> Images { get => _images; set => _images = value; }

    public Sprite GetImageByID(int id)
    {
        return _images[id];
    }
}
