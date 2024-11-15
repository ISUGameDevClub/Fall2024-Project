using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Sound : ScriptableObject
{
    //public string itemName;
    //public int quantity;
    //public Sprite icon;

    public string name;
    public AudioClip clip;
    public float volume;
    public float pitch;
    public bool loop;

    public AudioSource source;
}
