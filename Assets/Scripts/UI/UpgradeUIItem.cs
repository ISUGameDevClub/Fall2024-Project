using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UpgradeUIItem : MonoBehaviour
{
    private TMP_Text currentValue;
    private TMP_Text nextValue;
    public GameObject currentValueObj;
    public GameObject nextValueObj;
    public GameObject upgradeButton;
    [SerializeField] private Upgrade selectedUpgrade;

    public enum Upgrade
    {
        maxHealth,
        bulletDamage,
        ammoLimit,
        reloadSpeed,
        meleeSpeed,
        meleeDamage
    }

    // Start is called before the first frame update
    void Start()
    {
        currentValue = currentValueObj.GetComponent<TMP_Text>();
        nextValue = nextValueObj.GetComponent<TMP_Text>();
        upgradeButton.GetComponent<Button>().onClick.AddListener(UpgradeItem);
        currentValue.text = GetCurrentValue();
        nextValue.text = GetNextValue();
        upgradeButton.GetComponentInChildren<TMP_Text>().text = GetPrice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeItem() {
        GetUpgradeInfo().UpgradeItem();
        currentValue.text = GetCurrentValue();
        nextValue.text = GetNextValue();
        upgradeButton.GetComponentInChildren<TMP_Text>().text = GetPrice();
    }

    private UpgradeScript.UpgradePath GetUpgradeInfo(){
        switch (selectedUpgrade) {
            case Upgrade.ammoLimit:
                return UpgradeScript.instance.ammoLimit;
            case Upgrade.bulletDamage:
                return UpgradeScript.instance.bulletDamage;
            case Upgrade.maxHealth:
                return UpgradeScript.instance.maxHealth;
            case Upgrade.meleeDamage:
                return UpgradeScript.instance.meleeDamage;
            case Upgrade.meleeSpeed:
                return UpgradeScript.instance.meleeSpeed;
            case Upgrade.reloadSpeed:
                return UpgradeScript.instance.reloadSpeed;
        }
        return null;
    }

    private string GetCurrentValue() {
        UpgradeScript.UpgradePath currentUpgr = GetUpgradeInfo();
        if (currentUpgr.upgradesInt.Length != 0) {
            return currentUpgr.GetCurrentIntVal().ToString();
        } else if (currentUpgr.upgradesFloat.Length != 0) {
            return currentUpgr.GetCurrentFloatVal().ToString();
        }
        return "";
    }

    private string GetNextValue() {
        UpgradeScript.UpgradePath currentUpgr = GetUpgradeInfo();
        if (currentUpgr.upgradesInt.Length != 0 && (currentUpgr.upgradesInt.Length - 1) > currentUpgr.upgradeIndex) {
            return currentUpgr.upgradesInt[currentUpgr.upgradeIndex + 1].ToString();
        } else if (currentUpgr.upgradesFloat.Length != 0 && (currentUpgr.upgradesInt.Length - 1) <= currentUpgr.upgradeIndex) {
            return currentUpgr.upgradesFloat[currentUpgr.upgradeIndex + 1].ToString();
        }
        return "max";
    }

    private string GetPrice() {
        UpgradeScript.UpgradePath currentUpgr = GetUpgradeInfo();
        if ((currentUpgr.upgradesInt.Length - 1) < currentUpgr.upgradeIndex + 1) {
            upgradeButton.GetComponent<Button>().interactable = false;
            return "maxed";
        }
        return currentUpgr.upgradeCost[currentUpgr.upgradeIndex + 1].ToString();
    }
}
