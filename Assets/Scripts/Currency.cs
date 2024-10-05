using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int playerCurrency = 0;


    public bool AddCurrency(int amount)
    {
        playerCurrency += amount;
        return true;
    }

    public bool RemoveCurrency(int amount)
    {
        if (playerCurrency - amount < 0)
        {
            return false;
        }
        else
        {
            playerCurrency -= amount;
            return true;
        }
    }

    public int GetCurrency()
    {
        return playerCurrency;
    }
    public bool SetCurrency(int amount)
    {
        if (amount < 0)
        {
            return false;
        }
        else
        {
            playerCurrency = amount;
            return true;
        }
    }

    public bool CanDeductCurrency(int amount)
    {
        if (playerCurrency - amount < 0)
        {
           return false;
        }
        else
        {
            return true;
        }
    }
}
