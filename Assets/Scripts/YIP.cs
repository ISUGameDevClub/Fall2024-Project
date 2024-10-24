using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class YIP : MonoBehaviour
{
    public int fame = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFame(int score)
    {
        if (fame+score>500) {
            fame = 500;
        }
        else
        {
            fame += score;
        }
    }
    public void RemoveFame(int score)
    {
        if (fame - score < 0)
        {
            fame = 0;
            // Run Function to send player to game over screen HERE.
        }
        else
        {
            fame -= score;
        }
    }
    public int GetFame()
    {
        return fame;
    }
    public void SetFame(int score)
    {
        // MT: Dont forget to add limits so we can set score over 500 or set it to 0
        fame = score;
    }
}
