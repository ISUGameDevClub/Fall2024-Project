using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// struct with enemy prefab and spawn weight
[System.Serializable]
public struct EnemySpawn
{
    public GameObject enemyPrefab;
    public int spawnWeight;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private LayerMask spawnableLayerMask;
    [SerializeField] private EnemySpawn[] enemySpawns;

    [SerializeField] private int minEnemiesToSpawn = 5;
    [SerializeField] private int maxEnemiesToSpawn = 10;

    [SerializeField] private Transform spawnZonePointA;
    [SerializeField] private Transform spawnZonePointB;

    private int totalSpawnWeight;

    private void Start()
    {
        // calculate total spawn weight
        foreach (EnemySpawn enemySpawn in enemySpawns)
        {
            totalSpawnWeight += enemySpawn.spawnWeight;
        }

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        int enemiesToSpawn = Random.Range(minEnemiesToSpawn, maxEnemiesToSpawn);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // get random enemy spawn
            EnemySpawn randomEnemySpawn = GetRandomEnemySpawn();

            // get random spawn position
            Vector3 spawnPosition = GetRandomSpawnPosition();

            // spawn enemy
            GameObject newEnemy = Instantiate(randomEnemySpawn.enemyPrefab, spawnPosition, Quaternion.identity);

            // set wander zone
            EnemyCore enemyCore = newEnemy.GetComponentInChildren<EnemyCore>();
            enemyCore.movement.SetWanderZone(spawnZonePointA, spawnZonePointB);

            // make child
            newEnemy.transform.parent = transform;
        }
    }

    private EnemySpawn GetRandomEnemySpawn()
    {
        int randomValue = Random.Range(0, totalSpawnWeight);

        int weightSum = 0;

        foreach (EnemySpawn enemySpawn in enemySpawns)
        {
            weightSum += enemySpawn.spawnWeight;

            if (randomValue <= weightSum)
            {
                return enemySpawn;
            }
        }

        Debug.LogError("Enemy Spawn Slection Error!");
        return enemySpawns[0];
    }

    private Vector3 GetRandomSpawnPosition()
    {

        // Debug.Log("Getting Random Spawn Position");
        int maxTrials = 100;

        for (int i = 0; i < maxTrials; i++)
        {
            // pick a random point in the spawn zone
            Vector3 randomRaycastStartPoint = new Vector3(
                Random.Range(spawnZonePointA.position.x, spawnZonePointB.position.x),
                spawnZonePointA.position.y + 50,
                Random.Range(spawnZonePointA.position.z, spawnZonePointB.position.z)
            );
            // create a raycast from the random point
            Ray ray = new Ray(randomRaycastStartPoint, Vector3.down);
            RaycastHit hit;
            // if the ray hits the ground, return point
            if (Physics.Raycast(ray, out hit, 100, spawnableLayerMask))
            {
                return hit.point;
            }
        } 

        Debug.LogError("Failed to get Random Spawn Position");
        return Vector3.zero;
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube( 
            (spawnZonePointA.position + spawnZonePointB.position) / 2, 
            spawnZonePointB.position - spawnZonePointA.position + Vector3.up * 50f);
    }

}
