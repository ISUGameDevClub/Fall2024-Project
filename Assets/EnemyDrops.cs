using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : EnemyScript
{
    public GameObject[] droppedItems;
    public float dropChances = .5f;
    // Start is called before the first frame update
    void Start()
    {
        core.health.enemyDeath += OnEnemyDeath;
    }

    void OnEnemyDeath()
    {
        if(Random.value <= dropChances)
        {
            int randommap = Random.Range(0, droppedItems.Length);

            Instantiate(droppedItems[randommap], transform.position, Quaternion.identity);//Will be changed to inventory
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
