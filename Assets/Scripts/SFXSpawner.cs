using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSpawner : MonoBehaviour
{
    [System.Serializable]
    class SoundObj {
        public SoundEffectAsset soundAsset;
        public string soundName;
    }

    private int soundCount;
    public static SFXSpawner instance;
    [SerializeField] SoundObj[] soundArray;
    AudioSource audioSource;
    [SerializeField] bool isGlobalInstance;

    void Awake() {
        if (instance == null && isGlobalInstance) {
            instance = this;
        }
    }

    private void spawnSound(AudioClip soundClip)
    {
        GameObject newSoundObject = new GameObject("SFX Emiter");
        AudioSource objectAudioSoruce = newSoundObject.AddComponent<AudioSource>();
        //play a sound
        objectAudioSoruce.PlayOneShot(soundClip);
        //destory the object
        Destroy(newSoundObject, soundClip.length + 1);
    }

    public bool playSoundByString(string soundName)
    {
        foreach(SoundObj soundRef in soundArray) {
            if (soundRef.soundName == soundName) {
                //play the sound
                spawnSound(soundRef.soundAsset.GetRandomSound());
                return true;
            }
        }
        Debug.LogError("Error: '" + soundName + "' does not exist in array");
        return false;
    }

    public void playSoundByObject(SoundEffectAsset soundAsset) {
        spawnSound(soundAsset.GetRandomSound());
    }
}
