using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    Health playerHeath;
    DayNightCycle timeCycle;
    public Vector3 wakeLocation;
    public float timeSpentDead=9.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerHeath = FindObjectOfType<Health>();
        //timeCycle = FindObjectOfType<DayNightCycle>();  //call a DNCycle 
        
        playerHeath.playerDeath += OnPlayerDeath;
    }

    void OnPlayerDeath()
    {
        Debug.Log("Respawn Thingy Here");
        //timeCycle.addTimeToPassing(timeSpentDead); //add time to DNCycle
        //scene transition
        //return player to wakeLocation 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
