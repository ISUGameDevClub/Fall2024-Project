using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndGameStats : MonoBehaviour
{
    public TMP_Text moneyEarnedTxt;
    public TMP_Text yipEarnedTxt;
    public TMP_Text customersServedTxt;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.instance.dayStats.moneyAccumulated);
        moneyEarnedTxt.text = "+ $" + GameManager.instance.dayStats.moneyAccumulated.ToString();
        yipEarnedTxt.text = "+ "+ GameManager.instance.dayStats.moneyAccumulated.ToString() + " YIP";
        customersServedTxt.text = GameManager.instance.dayStats.customersServed.ToString() + "Served";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
