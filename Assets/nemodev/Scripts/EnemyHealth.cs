using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType {
    Melee,
    Ranged,
}

public class EnemyHealth : EnemyScript
{
    public Action enemyDeath;
    public Action<float> enemyHit;

    [SerializeField] public float maxHealth = 10f;
    [SerializeField] private bool bunkerNegatesMelee = false;
    [SerializeField] private bool bunkerNegatesRanged = true;
    
    public float health {get; private set;}

    void Start() {
        health = maxHealth;
    }

    public void TakeDamage(float damage, AttackType type) {

        if (core.movement.state == EnemyMovementState.Bunker) {
            if (type == AttackType.Melee && bunkerNegatesMelee) {
                enemyHit?.Invoke(0f);
                return;
            }
            if (type == AttackType.Ranged && bunkerNegatesRanged) {
                enemyHit?.Invoke(0f);
                return;
            }
        }

        health -= damage;
        enemyHit?.Invoke(damage);
        if (health <= 0) {
            core.rb.constraints = RigidbodyConstraints.None;
            
            enemyDeath.Invoke();
        }
    }

    public bool isDead => health <= 0;

}
