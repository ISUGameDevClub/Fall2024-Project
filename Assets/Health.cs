using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Health : MonoBehaviour {
    public int curHealth = 0;
    public int maxHealth = 100;
    public int minHealth = 0;
    public HealthBar healthBar;
    public static Health healthInstance;
    private Vector3 spawnLocation;
    public Action playerDeath;

    //private UnityAction m_healthFunction;

    void Awake() {
        if(healthInstance=null){
            healthInstance=this;
        }
    }

    void Start() {
        curHealth = maxHealth;
        healthBar = FindAnyObjectByType<HealthBar>();
        maxHealth = UpgradeScript.instance.maxHealth.GetCurrentIntVal();
        UpgradeScript.instance.onUpgradeUpdate += OnUpgradeUpdate;
        spawnLocation = transform.position;
    }
    public void DamagePlayer(int damage) {
        curHealth -= damage;
        if(curHealth<1) {
            Debug.Log("You dead. Thanks for playing.");
            playerDeath?.Invoke();
            FindAnyObjectByType<sceneTransition>().PlayerDeathTransition();
            FindAnyObjectByType<DayNightCycle>().addTimeToPassing(20);
            curHealth = maxHealth;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = spawnLocation;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = true;
        }
        healthBar.SetHealth(curHealth);
    }

    public void HealPlayer(int heal) {
        curHealth += heal;
        healthBar.SetHealth(curHealth);
    }

    public int getCurHealth() {
        return curHealth;
    }
    void OnUpgradeUpdate()
    {
        maxHealth = UpgradeScript.instance.maxHealth.GetCurrentIntVal();
    }
}