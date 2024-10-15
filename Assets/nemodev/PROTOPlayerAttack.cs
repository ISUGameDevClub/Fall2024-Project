using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS IS A PROTOTYPE SCRIPT FOR TESTING ENEMY HEALTH
// THIS SHOULD NOT BE USED IN THE FINAL GAME
public class PROTOPlayerAttack : MonoBehaviour
{
    // list of enemies currently in trigger
    private List<EnemyCore> enemiesInTrigger = new List<EnemyCore>();

    private void OnTriggerEnter(Collider other) {
        // check if enemy tag
        if (other.CompareTag("Enemy")) {
            // add enemy to list
            enemiesInTrigger.Add(other.GetComponentInParent<EnemyCore>());
        }

    }

    private void OnTriggerExit(Collider other) {
        // check if enemy tag
        if (other.CompareTag("Enemy")) {
            // add enemy to list
            enemiesInTrigger.Remove(other.GetComponentInParent<EnemyCore>());
        }
    }

    private void Update() {
        // check if player is attacking
        if (Input.GetMouseButtonDown(0)) {
            // loop through all enemies in trigger
            foreach (EnemyCore enemy in enemiesInTrigger) {
                
                // damage enemy
                enemy.health.TakeDamage(5f);

                // knockback enemy
                Vector3 direction = enemy.rb.transform.position - transform.position;
                direction.y = 0;
                enemy.knockback.Knockback(direction, 5f);
                
            }
        }
    }
}
