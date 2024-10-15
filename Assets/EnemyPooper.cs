using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooper : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private EnemyMovementState[] statesToSpawnOn;


    IEnumerator PoopRoutine() {
        while (true) {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
