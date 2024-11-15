using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    Dictionary<string, Sound> tracks;

    public static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            foreach (KeyValuePair<string, Sound> track in instance)
            {
                track.source = gameObject.AddComponent<AudioSource>();

                track.source.clip = track.clip;
                track.source.volume = track.volume;
                track.source.pitch = track.pitch;
                track.source.loop = track.loop;
            }
        }
        else
        {
            Destroy(GameObject);
        }
    }

    void playMusic(string trackName)
    {
        track = tracks[trackName];
        if (track)
        {
            track.source.Play();
        }
        else
        {
            Debug.LogWarning(name + " sound not found!");
        }
    }


}


//The script should have a public Dictionary or hash table of sounds that can be selected and played
//A public static variable with the Music Manager script data type to store its instance as a reference for other scripts to access without using the getcomponent method
//A single public function will be called and the argument will be a string of what song to play. The function will find what track to pay from the array
