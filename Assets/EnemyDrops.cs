using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public struct DropItemInfo
{

    public Item item;
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
                    InventoryManager.instance.AddItem(item.item, item.amount);
                    FindAnyObjectByType<PlayerNotificationManager>().SpawnPickupNotifi(item.item.icon, item.amount);
                }
            }
        }
    }

}
