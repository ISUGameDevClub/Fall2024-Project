using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : EnemyScript
{
    // MT: replace with the scriptable object of the items in here.
    public Item[] droppedItems;
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
            // MT: Get the items name string and put it in the add Item Function for Inventory
            int randommap = Random.Range(0, droppedItems.Length);
            // Import New Inventory system and use the add functions
            InventoryManager.instance.AddItem(droppedItems[0]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
