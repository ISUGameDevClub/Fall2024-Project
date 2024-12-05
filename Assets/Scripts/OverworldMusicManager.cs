using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OverworldMusicManager : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioClip exploreClip;
    public AudioClip fightClip;
    public float fadeDuration = 2.0f;
    private AudioSource currentSong;
    private AudioSource nextSource;

    public List<GameObject> gameObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        currentSong = audioSource1;
        nextSource = audioSource2;

        currentSong.clip = exploreClip;
        currentSong.Play();
        currentSong.volume = 1f;
        nextSource.volume = 0f;
    }

    public void Add(GameObject obj)
    {
        if (!gameObjects.Contains(obj))
        {
            gameObjects.Add(obj);
        }
        if (gameObjects.Count == 0) {
            PlayExplore();
        } else {
            PlayFight();
        }
    }

    public void Remove(GameObject obj)
    {
        if (gameObjects.Contains(obj))
        {
            gameObjects.Remove(obj);
        }
        if (gameObjects.Count == 0) {
            PlayExplore();
        } else {
            PlayFight();
        }
    }

    public void PlayExplore() {
        if (currentSong.clip != exploreClip) {
            StartCoroutine(FadeToNewSong(exploreClip));
        }
    }

    public void PlayFight() {
        if (currentSong.clip != fightClip) {
            StartCoroutine(FadeToNewSong(fightClip));
        }
    }

    private IEnumerator FadeToNewSong(AudioClip newSong) {
        nextSource.clip = newSong;
        nextSource.Play();

        float startVolume = currentSong.volume;
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration) {
            currentSong.volume = Mathf.Lerp(startVolume, 0, timeElapsed / fadeDuration);
            nextSource.volume = Mathf.Lerp(0, startVolume, timeElapsed / fadeDuration);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        currentSong.volume = 0;
        nextSource.volume = startVolume;

        currentSong.Stop();
        AudioSource temp = currentSong;
        currentSong = nextSource;
        nextSource = temp;
    }

    void Update() {
        // if (Input.GetKeyDown(KeyCode.LeftBracket)) {
        //     PlayExplore();
        // }
        // if (Input.GetKeyDown(KeyCode.RightBracket)) {
        //     PlayFight();
        // }
    }
}
