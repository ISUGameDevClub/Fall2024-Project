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

    public Action playerDeath;

    //private UnityAction m_healthFunction;

    void Awake() {
        if(healthInstance=null){
            healthInstance=this;
        }
    }

    void Start() {
        curHealth = maxHealth;
        Debug.Log("You are starting with " + curHealth + " HP.");
        Debug.Log("Push the spacebar to kill yourself.");
        healthBar = FindAnyObjectByType<HealthBar>();
        //m_healthFunction += DamagePlayer;
        //m_healthFunction += HealPlayer;
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            int damage = 10;
            if(curHealth == 0) {
                Debug.Log("Stop it. Stop it. You're already dead.");
            } else {
                Debug.Log("Ouch! You did " + damage + " damage..");
                DamagePlayer(damage);
            }
        }
        if(Input.GetKeyDown(KeyCode.H)) {
            int heal = 10;
            if(curHealth == maxHealth) {
                Debug.Log("You're already at full health.");
            } else {
                Debug.Log("Phew! You healed by " + heal + " health points.");
                HealPlayer(heal);
            }
        }
    }
    public void DamagePlayer(int damage) {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        Debug.Log("You are now at " + curHealth + " health.");
        if(curHealth<1) {
            Debug.Log("You dead. Thanks for playing.");
            playerDeath?.Invoke();
        }
    }

    public void HealPlayer(int heal) {
        if(curHealth == 0) {
            Debug.Log("Welcome back to life, cheater.");
        }
        curHealth += heal;
        healthBar.SetHealth(curHealth);
        Debug.Log("You are now at " + curHealth + " health.");
    }

    public int getCurHealth() {
        return curHealth;
    }
}