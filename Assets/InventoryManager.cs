using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    [System.Serializable]
    public class Item
    {
        public string itemName;
        public int quantity;
        public Sprite icon;
    }

    public void AddItem(Item item)
    {
        int i = inventory.IndexOf(item);
        //if list contains the item already, increase quantity
        if (i != -1)
            inventory[i].quantity++;
        //else add the item to inventory
        else
            inventory.Add(item);
    }

    public void RemoveItem(Item item)//type
    {
        if(inventory.Contains(item))
        {
            //decrease quantity of item
            int i = inventory.IndexOf(item);
            inventory[i].quantity--;
            //if no more of item left, remove from list
            if (inventory[i].quantity <= 0)
                inventory.RemoveAt(i);
        }     
    }
}
