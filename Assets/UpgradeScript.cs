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
    public delegate void UpgradeUpdate();
    public event UpgradeUpdate onUpgradeUpdate;
    public static UpgradeScript instance;

    [System.Serializable]  // Mark the class as serializable
    public class UpgradePath
    {
        public string upgradeDisplayName;
        public int[] upgradeCost = { 20, 20, 20, 20, 20, 20 };
        public int[] upgradesInt = { };
        public float[] upgradesFloat = { };
        public Sprite icon;
        public int upgradeIndex = 0;

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
            UpgradeScript.instance.UpdateUI();
            if ((upgradeCost.Length - 1) > upgradeIndex && Currency.instance.CanDeductCurrency(upgradeCost[upgradeIndex])) {
                Currency.instance.RemoveCurrency(upgradeCost[upgradeIndex + 1]);
                upgradeIndex++;
                instance.onUpgradeUpdate?.Invoke();
                return true;
            }
            return false;
        }
    }

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
    public void UpdateUI()
    {
        Debug.Log("Update UI");
        onUpgradeUpdate?.Invoke();
    }
        
    

    
}
