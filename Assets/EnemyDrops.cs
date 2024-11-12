using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public struct DropItemInfo
{

    public GameObject item;
    public int amount;
    public float dropChance;
}


public class EnemyDrops : EnemyScript
{
    // MT: replace with the scriptable object of the items in here.
    public DropItemInfo[] droppedItems;

    // Start is called before the first frame update
    void Start()
    {
        core.health.enemyDeath += OnEnemyDeath;
    }

    void OnEnemyDeath()
    {
        foreach (DropItemInfo item in droppedItems)
        {
            if (Random.value <= item.dropChance)
            {
                for (int i = 0; i < item.amount; i++)
                {
                    Instantiate(item.item, transform.position, Quaternion.identity);
                }
            }
        }
    }

}
