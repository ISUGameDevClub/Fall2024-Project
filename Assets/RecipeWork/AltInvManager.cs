using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AltInvManager : MonoBehaviour
{
    public AltItem[] inventory;
    public static AltInvManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // MT: I would suggest to have a optional arg to define how many times to add instead of one.
    public void AddItem(AltItem itemObj, int quantity = 1)
    {
        inventory[itemObj.arrayPos].quantity += quantity;
    }

    // MT: Same for this one to have a arg.
    public void RemoveItem(AltItem itemObj, int quantity = 1)
    {
        if (inventory[itemObj.arrayPos].quantity > 0)
        {
            inventory[itemObj.arrayPos].quantity -= quantity;
        }
        return;
    }

    public AltItem[] GetAll()
    {
        return inventory;
    }
}
