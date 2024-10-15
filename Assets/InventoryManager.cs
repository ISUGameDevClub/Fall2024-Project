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

    public void AddItem(string itemName)
    {
        //cycle through list and find item with matching name, then increase quantity
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName.Equals(itemName))
                inventory[i].quantity++;
        }
    }

    public void RemoveItem(string itemName)
    {
        //cycle through list and find item with matching name, then decrease quantity
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName.Equals(itemName))
                inventory[i].quantity--;
        }
    }

    public List<Item> GetAll()
    {
        return inventory;
    }
}
