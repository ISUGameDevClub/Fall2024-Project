using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.WSA;

public enum EnemyAttackType {
    Melee,
    Ranged,
}

public class EnemyAttack : EnemyScript
{
    public Action attackStart;
    public Action<bool> attackExecute;
    public Action attackEnd;


    public bool isAttacking {get; private set;} = false;


    [SerializeField] EnemyAttackType attackType;

    [SerializeField] float attackRangeMin = 0.25f;
    [SerializeField] float attackRangeMax = 5f;

    [SerializeField] float attackCooldownMin = 1f;
    [SerializeField] float attackCooldownMax = 5f;

    [SerializeField] float attackDurration = 2f;
    [SerializeField] float attackWindup = 0.1f;


    [SerializeField] float meleeRange = 1f;
    [SerializeField] float meleeDamage = 10f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileLaunchShift = 0.5f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField, Range(0f,180f)] float projectileAccuracy = 10f;
    [SerializeField] int projectilesTooShoot = 1;
    [SerializeField] float timeBetweenProjectiles = 0.1f;

    Coroutine attackCheckCoroutineRef;

    private void Start() {
        core.movement.behaviorStateChange += OnEnemyBehaviodStateChange;
        core.health.enemyDeath += OnEnemyDeath;
    }

    private void OnEnemyDeath() {
        if (attackCheckCoroutineRef != null)
            StopCoroutine(attackCheckCoroutineRef);
    }

    private void OnEnemyBehaviodStateChange(EnemyMovementState state) {
        if (state == EnemyMovementState.Persuit && ! core.health.isDead) {
            if (attackCheckCoroutineRef != null)
                StopCoroutine(attackCheckCoroutineRef);
            attackCheckCoroutineRef = StartCoroutine(attackCheckCoroutine());
        } else {
            if (attackCheckCoroutineRef != null)
                StopCoroutine(attackCheckCoroutineRef);
        }
    }



    IEnumerator attackCheckCoroutine() {
        while (true) {
            yield return new WaitForSeconds(UnityEngine.Random.Range(attackCooldownMin,attackCooldownMax));
        
            float dist = Vector3.Distance(core.player.transform.position,transform.position);
            if (dist < attackRangeMax && dist > attackRangeMin) {
                switch (attackType) {
                    case EnemyAttackType.Melee:
                        StartCoroutine(MeleeAttackCoroutine());
                        break;
                    case EnemyAttackType.Ranged:
                        StartCoroutine(RangedAttackCoroutine());
                        break;
                }
            }

            while (isAttacking) {
                yield return new WaitForFixedUpdate();
            }
        }
    }

    IEnumerator MeleeAttackCoroutine() {
        isAttacking = true;
        attackStart?.Invoke();
        yield return new WaitForSeconds(attackWindup);
        // check if player is in melee range
        float dist = Vector3.Distance(core.player.transform.position,transform.position);
        if (dist < meleeRange) {
            attackExecute?.Invoke(true);
            Debug.Log("Player in range for melee attack");
            // melee attack code here
        } else {
            attackExecute?.Invoke(false);
            Debug.Log("Player out of range for melee attack");
        }
        yield return new WaitForSeconds(attackDurration-attackWindup);
        isAttacking = false;
        attackEnd?.Invoke();
    }


    IEnumerator RangedAttackCoroutine() {
        isAttacking = true;
        attackStart?.Invoke();
        yield return new WaitForSeconds(attackWindup);
        for (int i = 0; i < projectilesTooShoot; i++) {
            attackExecute?.Invoke(true);
            // calculate the direction to shoot the projectile
            float shiftSign = math.sign(core.player.transform.position.x - transform.position.x);
            Vector3 launchPosition = transform.position + shiftSign * projectileLaunchShift * Vector3.right;

            Vector3 direction = core.player.transform.position - launchPosition;
            // direction.y = 0;
            direction.Normalize();
            // add some randomness to the direction
            direction = Quaternion.Euler(0,UnityEngine.Random.Range(-projectileAccuracy,projectileAccuracy),0) * direction;
            // create the projectile
            GameObject projectile = Instantiate(projectilePrefab,launchPosition,Quaternion.identity);
            // set the projectile speed
            projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
            // wait for the next projectile
            yield return new WaitForSeconds(timeBetweenProjectiles);
        }
        yield return new WaitForSeconds(attackDurration-attackWindup-projectilesTooShoot*timeBetweenProjectiles);
        isAttacking = false;
        attackEnd?.Invoke();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,attackRangeMax);
        // Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,attackRangeMin);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,meleeRange);
    }

}
