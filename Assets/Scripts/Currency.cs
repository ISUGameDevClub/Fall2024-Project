using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int playerCurrency = 0;
    public bool wasSuccessful = false;

    public bool AddCurrency(int amount)
    {
        playerCurrency += amount;
        return wasSuccessful = true;
    }

    public bool RemoveCurrency(int amount)
    {
        if (playerCurrency - amount < 0)
        {
            return wasSuccessful = false;
        }
        else
        {
            playerCurrency -= amount;
            return wasSuccessful = true;
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
            return wasSuccessful = false;
        }
        else
        {
            playerCurrency = amount;
            return wasSuccessful = true;
        }
    }

    public bool CanDeductCurrency(int amount)
    {
        if (playerCurrency - amount < 0)
        {
           return wasSuccessful = false;
        }
        else
        {
            return wasSuccessful = true;
        }
    }
}
