using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SFX Asset", menuName = "Audio/SFX Asset Refrence")]
public class SoundEffectAsset : ScriptableObject
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
