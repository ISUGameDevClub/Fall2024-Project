using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] int playerCurrency = 0;
    public static Currency instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

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

    public bool CanDeductCurrency(int amount) // Is this method necessary?  [Mtunberg] Yes, its a good function to have for UI
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
