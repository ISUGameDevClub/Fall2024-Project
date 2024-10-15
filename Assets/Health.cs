using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;
    void Start() {
        curHealth = maxHealth;
        Debug.Log("You are starting with " + curHealth + " HP.");
        Debug.Log("Push the spacebar to kill yourself.");
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            int damage = 10;
            Debug.Log("Ouch! You did " + damage + " damage..");
            DamagePlayer(damage);
        }
    }
    public void DamagePlayer(int damage) {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        Debug.Log("You are now at " + curHealth + " health.");
        if(curHealth<1) {
            Debug.Log("You dead. Thanks for playing.");
        }
    }
}