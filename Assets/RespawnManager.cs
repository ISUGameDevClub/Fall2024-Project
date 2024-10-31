using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject player;
    Health playerHealth;
    public DayNightCycle timeCycle;
    public sceneTransition curtainsCloser;
    public Vector3 wakeLocation;
    public float timeSpentDead=9.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<Health>();
        timeCycle = FindObjectOfType<DayNightCycle>();  //call a DNCycle 
        wakeLocation = player.transform.position;
    }

    void OnPlayerDeath()
    {
        Debug.Log("Respawn Thingy Here");
        timeCycle.addTimeToPassing(timeSpentDead); //add time to DNCycle
        //scene transition
        
        //return player to wakeLocation 
        player.transform.position = wakeLocation;
        playerHealth.curHealth = playerHealth.maxHealth;
        curtainsCloser.PlayerDeathTransition();
        Debug.Log("Respawn Thingy there");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.curHealth < 1 || Input.GetKey("o"))
        {
            OnPlayerDeath();
        }

    }
}
