using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectAsset : MonoBehaviour
{
public List<AudioClip> soundClips;
    public string soundName;
    public float volume;
    public bool loop;

    public AudioClip GetRandomSound() {
        int randomIndex = Random.Range(0, soundClips.Count);
        return soundClips[randomIndex];
    }

    public AudioClip GetFirstSound() {
        return soundClips[0];
    }
}
