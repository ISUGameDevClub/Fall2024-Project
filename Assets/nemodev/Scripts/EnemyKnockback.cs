using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : EnemyScript
{
    public bool isBeingKnockedBack {get; private set;} = false;

    public void Knockback(Vector3 direction, float force) {
        

        core.movement.navAgent.enabled = false;
        core.rb.isKinematic = false;

        core.rb.AddForce(direction.normalized * force + Vector3.up * 2f, ForceMode.Impulse);

        if (!isBeingKnockedBack) {
            isBeingKnockedBack = true;
            StartCoroutine(WaitUntilStopped());
        }

        // core.movement.navAgent.velocity = direction.normalized * force + Vector3.up * 2f;
    }

    private IEnumerator WaitUntilStopped() {
        yield return new WaitForSeconds(0.1f);// wait for the enemy to start moving from force
        while (core.rb.velocity.magnitude > 0.5f) {
            // Debug.Log(core.rb.velocity.magnitude);
            yield return new WaitForFixedUpdate();
        }
        // Debug.Log("Stopped, resuming navigation");
        
        if (!core.health.isDead) {
            core.movement.navAgent.enabled = true;
            core.rb.isKinematic = true;
            yield return new WaitForSeconds(0.1f); // to fix a bug where the enemy would go back to standard movement state
            core.movement.SetMovementState(core.movement.stateWhenEnemyHit);
        }

        isBeingKnockedBack = false;
    }
}
