using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    private TMP_Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        moneyText.text = "$" + Currency.instance.GetCurrency().ToString();
    }

    void Update() {
        moneyText.text = "$" + Currency.instance.GetCurrency().ToString();
    }
}
