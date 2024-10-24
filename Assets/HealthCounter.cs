using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class HealthCounter : MonoBehaviour {
    public TMP_Text healthCounter;
    string healthText;
    private Health theHealth;
    public GameObject Health;

    
    // Start is called before the first frame update
    void Start() {
        theHealth = Health.GetComponent<Health>();
    }

    // Update is called once per frame
    public void Update() {
        healthCounter.text = theHealth.getCurHealth().ToString();
    }
}