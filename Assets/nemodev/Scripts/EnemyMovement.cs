using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyMovementState {
    Wander,
    Persuit,
    Flee,
}

public class EnemyMovement : EnemyScript
{
    NavMeshAgent navAgent;

    public EnemyMovementState state {get; private set;} = EnemyMovementState.Wander;

    [SerializeField] Transform wanderZonePointA;
    [SerializeField] Transform wanderZonePointB;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float wanderNewLocationDelayMin = 1f;
    [SerializeField] float wanderNewLocationDelayMax = 15f;

    [SerializeField] float persuitDelay = 0.2f;

    [SerializeField] float persuitSpeed = 5f;
    float standardSpeed;

    [SerializeField] float fleeSpeed = 5f;
    [SerializeField] float fleeDistance = 5f;
    [SerializeField] float fleeDelay = 0.5f;

    [SerializeField] float fleeTimeUntilZoneReturn = 15f;


    Coroutine movementCoroutine;



    void Awake(){
        navAgent = GetComponentInChildren<NavMeshAgent>();
        standardSpeed = navAgent.speed;
    }

    private void Start() {
        SetFlee();
    }

    public void SetMovementState(EnemyMovementState newState) {
        state = newState;
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
        movementCoroutine = StartCoroutine(PersuePlayer());
        navAgent.speed = persuitSpeed;
    }

    private void SetWander() {
        if (movementCoroutine != null) {
            StopCoroutine(movementCoroutine);
        }
        movementCoroutine = StartCoroutine(Wander());
        navAgent.speed = standardSpeed;
    }

    private void SetFlee() {
        if (movementCoroutine != null) {
            StopCoroutine(movementCoroutine);
        }
        movementCoroutine = StartCoroutine(FleePlayer());
        navAgent.speed = fleeSpeed;
    }


    void SetWanderZone(Transform pointA, Transform pointB) {
        wanderZonePointA = pointA;
        wanderZonePointB = pointB;
    }

    IEnumerator Wander() {
        // pick a new spot to wander to by raycasting down from a random point in the wander zone

        while(true) {
            bool searchingForNewWanderPoint = true;
            do
            {
                // pick a random point in the wander zone
                Vector3 randomRaycastStartPoint = new Vector3(
                    Random.Range(wanderZonePointA.position.x, wanderZonePointB.position.x),
                    wanderZonePointA.position.y + 50,
                    Random.Range(wanderZonePointA.position.z, wanderZonePointB.position.z)
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

            // wait for a random amount of time before wandering again
            yield return new WaitForSeconds(Random.Range(wanderNewLocationDelayMin, wanderNewLocationDelayMax));
        }
    }

    IEnumerator PersuePlayer() {
        while (true) {
            navAgent.SetDestination(core.player.position);
            yield return new WaitForSeconds( persuitDelay);
        }
    }

    IEnumerator FleePlayer() {
        float timeLastSeenPlayer = Time.time;
        while (true) {
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

    void OnDrawGizmos() {
        if (wanderZonePointA != null && wanderZonePointB != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(
                (wanderZonePointA.position + wanderZonePointB.position) / 2, 
                new Vector3(Mathf.Abs(wanderZonePointA.position.x - wanderZonePointB.position.x), 
                1, 
                Mathf.Abs(wanderZonePointA.position.z - wanderZonePointB.position.z)));
        }
    }
}
