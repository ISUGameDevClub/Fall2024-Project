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

    // Just adding this so I can see the health property
    [SerializeField]
    private float seeHealth;

    void Start() {
        health = maxHealth;
        seeHealth = health;
        enemyDeath += destroyGameObject;
    }

    public void TakeDamage(float damage, AttackType type) {
        if (isDead) return;
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
        seeHealth = health;
        enemyHit?.Invoke(damage);
        if (health <= 0) {
            // core.rb.constraints = RigidbodyConstraints.None;
            
            enemyDeath.Invoke();
        }
    }

    public bool isDead => health <= 0;

    // Simple death behaviour, can be replaced
    public void destroyGameObject(){
        Destroy(this.gameObject);
    }

}
