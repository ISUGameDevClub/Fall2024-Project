using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooper : EnemyScript
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private EnemyMovementState[] statesToSpawnOn;


    Coroutine poopRoutineRef;

    private void Start() {
        core.movement.behaviorStateChange += OnStateChange;
    }

    private void OnStateChange(EnemyMovementState state) {
        foreach (EnemyMovementState s in statesToSpawnOn) {
            if (s == state) {
                if (poopRoutineRef != null)
                    StopCoroutine(poopRoutineRef);
                poopRoutineRef = StartCoroutine(PoopRoutine());
                return;
            }
        }
        if (poopRoutineRef != null)
            StopCoroutine(poopRoutineRef);
    }

    IEnumerator PoopRoutine() {
        while (true) {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
