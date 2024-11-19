using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    //vars for public upgrades
    public UpgradePath maxHealth;
    public UpgradePath bulletDamage;
    public UpgradePath ammoLimit;
    public UpgradePath reloadSpeed;
    public UpgradePath meleeSpeed;
    public UpgradePath meleeDamage;

    [System.Serializable]  // Mark the class as serializable
    public class UpgradePath
    {
        public string upgradeDisplayName;
        public int[] upgradeCost = { 20, 20, 20, 20, 20, 20 };
        public int[] upgradesInt = { };
        public float[] upgradesFloat = { };
        public Sprite icon;
        private int upgradeIndex = 0;

        public int GetCurrentIntVal() {
            if (upgradesInt.Length != 0) {
                return upgradesInt[upgradeIndex];
            }
            Debug.LogError("Upgrade Get Error: No upgrades for a Int Value. Array is empty");
            return 0;
        }
        public float GetCurrentFloatVal() {
            if (upgradesFloat.Length != 0) {
                return upgradesFloat[upgradeIndex];
            }
            Debug.LogError("Upgrade Get Error: No upgrades for a Float Value. Array is empty");
            return 0;
        }
        public bool UpgradeItem() {
            if (upgradeCost.Length >= (upgradeIndex + 1) && Currency.instance.CanDeductCurrency(upgradeCost[upgradeIndex + 1])) {
                Currency.instance.RemoveCurrency(upgradeCost[upgradeIndex + 1]);
                upgradeIndex++;
                return true;
            }
            return false;
        }
    }
    
    //health, pistolDamage,ammoLimit,reloadSpeed, meleeSpeed, meleeDamage;

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
