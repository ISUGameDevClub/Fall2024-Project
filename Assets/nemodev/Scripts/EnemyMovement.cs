using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyMovementState {
    Wander,
    Persuit,
    Flee,
    Bunker,
    Wait,

}

public enum BunkerExitCondition {
    Time,
    PlayerLost,
}

public class EnemyMovement : EnemyScript
{

    public Action<EnemyMovementState> behaviorStateChange;

    public NavMeshAgent navAgent {get; private set;}
    [SerializeField] LayerMask groundLayer;

    // movement behavior state
    public EnemyMovementState state {get; private set;}


    // wander zone box bounds. The enemy will wander to random points within this box
    [SerializeField] Transform wanderZonePointA;
    [SerializeField] Transform wanderZonePointB;

    // min and max delay between wandering around to new locations
    [SerializeField] float wanderNewLocationDelayMin = 1f;
    [SerializeField] float wanderNewLocationDelayMax = 15f;

    // delay between persuit navigation updates targeting the player
    [SerializeField] float persuitDelay = 0.2f;

    // speed of the enemy when persuing the player
    [SerializeField] float persuitSpeed = 5f;
    [SerializeField] float persuitDistance = 0f;

    [SerializeField] float timeUntilWanderAfterPlayerLost = 5f;

    float standardSpeed;

    // speed of the enemy when fleeing from the player
    [SerializeField] float fleeSpeed = 5f;

    // distance in direction away from the player to flee to
    [SerializeField] float fleeDistance = 5f;

    // delay between flee navigation updates
    [SerializeField] float fleeDelay = 0.5f;

    // time until the enemy returns to the wander state after not seeing the player
    [SerializeField] float fleeTimeUntilZoneReturn = 15f;

    // behavior state when player is seen
    [SerializeField] EnemyMovementState stateWhenPlayerSeen = EnemyMovementState.Wander;
    [field: SerializeField] public EnemyMovementState stateWhenEnemyHit {get; private set;} = EnemyMovementState.Persuit;

    [SerializeField] bool changeStateAfterAttack = false;
    [SerializeField] bool changeStateAfterAttackRequiresMeleeConnect = false;
    [SerializeField] EnemyMovementState stateAfterAttack = EnemyMovementState.Flee;

    Coroutine movementCoroutine;



    void Awake(){
        navAgent = GetComponentInChildren<NavMeshAgent>();
        standardSpeed = navAgent.speed;
    }

    private void Start() {
        SetWander();

        core.playerDetector.playerDetected += OnPlayerDetected;
        core.playerDetector.playerLost += OnPlayerLost;
        core.health.enemyDeath += OnEnemyDeath;
        core.health.enemyHit += OnEnemyHit;
        core.attack.attackExecute += OnAttack;
    }

    private void OnAttack(bool connect) {
        if (changeStateAfterAttack) {
            if (!changeStateAfterAttackRequiresMeleeConnect || connect) {
                SetMovementState(stateAfterAttack);
            }
        }
    }

    private void OnEnemyHit() {
        SetMovementState(stateWhenEnemyHit);
    }

    private void OnEnemyDeath() {
        if (movementCoroutine != null) {
            StopCoroutine(movementCoroutine);
        }
        //disable nav agent
        navAgent.enabled = false;
    }

    private void OnPlayerDetected() {
        SetMovementState(stateWhenPlayerSeen);
    }

    private void OnPlayerLost() {
        if ( state == EnemyMovementState.Persuit) {
            SetWait(timeUntilWanderAfterPlayerLost);
        }
    }

    public void SetWait(float waitTime) {
        if (movementCoroutine != null) {
            StopCoroutine(movementCoroutine);
        }
        state = EnemyMovementState.Wait;
        behaviorStateChange?.Invoke(state);
        movementCoroutine = StartCoroutine(Wait(waitTime));
    }

    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        SetMovementState(EnemyMovementState.Wander);
    }

    public void SetMovementState(EnemyMovementState newState) {
        if (core.health.isDead) {
            return;
        }
        switch (newState) {
            case EnemyMovementState.Wander:
                if (state != EnemyMovementState.Wander) {
                    SetWander();
                }
                break;
            case EnemyMovementState.Persuit:
                if (state != EnemyMovementState.Persuit) {
                    SetPersuit();
                }
                break;
            case EnemyMovementState.Flee:
                if (state != EnemyMovementState.Flee) {
                    SetFlee();
                }
                break;
        }
    }

    private void SetPersuit() {
        if (movementCoroutine != null) {
            StopCoroutine(movementCoroutine);
        }
        state = EnemyMovementState.Persuit;
        behaviorStateChange?.Invoke(state);
        movementCoroutine = StartCoroutine(PersuePlayer());
        navAgent.speed = persuitSpeed;
    }

    private void SetWander() {
        if (movementCoroutine != null) {
            StopCoroutine(movementCoroutine);
        }
        state = EnemyMovementState.Wander;
        behaviorStateChange?.Invoke(state);
        movementCoroutine = StartCoroutine(Wander());
        navAgent.speed = standardSpeed;
    }

    private void SetFlee() {
        if (movementCoroutine != null) {
            StopCoroutine(movementCoroutine);
        }
        state = EnemyMovementState.Flee;
        behaviorStateChange?.Invoke(state);
        movementCoroutine = StartCoroutine(FleePlayer());
        navAgent.speed = fleeSpeed;
    }


    public void SetWanderZone(Transform pointA, Transform pointB) {
        wanderZonePointA = pointA;
        wanderZonePointB = pointB;
    }

    IEnumerator Wander() {
        


        // pick a new spot to wander to by raycasting down from a random point in the wander zone
        while(true) {

            

            while(core.knockback.isBeingKnockedBack) {
                yield return new WaitForFixedUpdate();
            }

            bool searchingForNewWanderPoint = true;
            do
            {
                // pick a random point in the wander zone
                Vector3 randomRaycastStartPoint = new Vector3(
                    UnityEngine.Random.Range(wanderZonePointA.position.x, wanderZonePointB.position.x),
                    wanderZonePointA.position.y + 50,
                    UnityEngine.Random.Range(wanderZonePointA.position.z, wanderZonePointB.position.z)
                );

                // create a raycast from the random point
                Ray ray = new Ray(randomRaycastStartPoint, Vector3.down);
                RaycastHit hit;

                // if the ray hits the ground, set the destination to the hit point and stop searching
                if (Physics.Raycast(ray, out hit, 100, groundLayer))
                {
                    navAgent.SetDestination(hit.point);
                    searchingForNewWanderPoint = false;
                }

            } while ( searchingForNewWanderPoint );
            // Debug.Log("Wandering to " + navAgent.destination);
            
            // wait for a random amount of time before wandering
            yield return new WaitForSeconds(UnityEngine.Random.Range(wanderNewLocationDelayMin, wanderNewLocationDelayMax));
        }
    }

    IEnumerator PersuePlayer() {
        while (true) {
            while(core.knockback.isBeingKnockedBack) {
                yield return new WaitForFixedUpdate();
            }

            // direction from player to enemy
            Vector3 direction = core.player.position - core.rb.transform.position;
            direction.y = 0;
            direction.Normalize();

            Vector3 destination = core.player.position - direction * persuitDistance;

            navAgent.SetDestination(destination);
            yield return new WaitForSeconds( persuitDelay);
        }
    }

    IEnumerator FleePlayer() {
        float timeLastSeenPlayer = Time.time;
        while (true) {
            while(core.knockback.isBeingKnockedBack) {
                yield return new WaitForFixedUpdate();
            }
            // if close to player, flee in the opposite direction
            float dist = Vector3.Distance(core.rb.transform.position, core.player.position);

            if ( dist < fleeDistance ) {
                Vector3 fleeDirection = core.rb.transform.position - core.player.position;
                Vector3 fleeDestination = core.rb.transform.position + fleeDirection.normalized * fleeDistance;
                navAgent.SetDestination(fleeDestination);
                timeLastSeenPlayer = Time.time;
            } else {
                // if player has not been seen for a while, return to wander state
                if (Time.time - timeLastSeenPlayer > fleeTimeUntilZoneReturn) {
                    SetMovementState(EnemyMovementState.Wander);
                }
            }
            yield return new WaitForSeconds( fleeDelay );
        }
    }

}
