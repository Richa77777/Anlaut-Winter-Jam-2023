using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioClipContainer : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> _sounds = new List<AudioClip>();

    public List<AudioClip> Sounds { get => _sounds; set => _sounds = value; }

    public AudioClip GetAudioByName(string name)
    {
        return _sounds.Find(sound => sound.name == name);
    }
}
