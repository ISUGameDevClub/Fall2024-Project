using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    // MT: I would suggest to have a optional arg to define how many times to add instead of one.
    public void AddItem(string itemName)
    {
        //cycle through list and find item with matching name, then increase quantity
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName.Equals(itemName))
                inventory[i].quantity++;
        }
    }

    // MT: Same for this one to have a arg.
    public void RemoveItem(string itemName)
    {
        //cycle through list and find item with matching name, then decrease quantity
        for (int i = 0; i < inventory.Count; i++)
        {
            // I would also suggest to have it return a bool of true or false indicating if
            // you can take away the amount requested.
            if (inventory[i].itemName.Equals(itemName))
                inventory[i].quantity--;
        }
    }

    public List<Item> GetAll()
    {
        return inventory;
    }
}
