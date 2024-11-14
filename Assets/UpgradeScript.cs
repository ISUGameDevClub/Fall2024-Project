using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    //vars for public upgrades
    public int maxHealth;
    public float bulletDamage;
    public int ammoLimit;
    public float reloadSpeed;
    public float meleeSpeed;
    public float meleeDamage;
    
    //health, pistolDamage,ammoLimit,reloadSpeed, meleeSpeed, meleeDamage;
    public int[] upgradeCost = { 20, 20, 20, 20, 20, 20 };

    public float[] upgrades = { };

    public class upgradeClass
    {

    }

    public static UpgradeScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
    onUpgradeUpdate?.Invoke();
    }
    void UpdateUI()
    {
        
    }
    public delegate void UpgradeUpdate();

    public event UpgradeUpdate onUpgradeUpdate;

    
}
