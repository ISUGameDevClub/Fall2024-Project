using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public static InventoryManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // MT: I would suggest to have a optional arg to define how many times to add instead of one.
    public void AddItem(Item itemObj, int quantity = 1)
    {
        //cycle through list and find item with matching name, then increase quantity
        foreach(Item item in inventory)
        {
            if (item.itemName == itemObj.itemName) {
                item.quantity += quantity;
                return;
            }
        }
        inventory.Add(itemObj);
    }

    // MT: Same for this one to have a arg.
    public void RemoveItem(Item itemObj, int quantity = 1)
    {
        //cycle through list and find item with matching name, then decrease quantity
        for (int i = 0; i < inventory.Count; i++)
        {
            // I would also suggest to have it return a bool of true or false indicating if
            // you can take away the amount requested.
            if (inventory[i].itemName == itemObj.itemName) {
                // Return When nothing is in this item.
                if (inventory[i].quantity <= 0) {return;}
                inventory[i].quantity -= quantity;
                return;
            }
        }
    }

    public bool CheckCanCraft(Item itemObj, int quanitiy = 1) {
        foreach(Item selItem in inventory)
        {
            // I would also suggest to have it return a bool of true or false indicating if
            // you can take away the amount requested.
            if (selItem.itemName == itemObj.itemName) {
                // Return When nothing is in this item.
                if (selItem.quantity <= 0) {return false;}
                if (selItem.quantity >= quanitiy) {return true;}
            }
        }
        return false;
    }

    public List<Item> GetAll()
    {
        return inventory;
    }
}
