using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EnemyScript
{
    public Action enemyDeath;

    [SerializeField] public float maxHealth = 10f;
    
    public float health {get; private set;}

    void Start() {
        health = maxHealth;
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            enemyDeath.Invoke();
        }
    }

    public bool isDead => health <= 0;

}
