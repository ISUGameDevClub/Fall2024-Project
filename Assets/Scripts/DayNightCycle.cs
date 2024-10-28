using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DayNightCycle : MonoBehaviour
{
    private float timePassed = 0;
    private string clock = "";
    private bool cycle = true;
    public int dayLengthInSec = 300;
    public GameObject clockHand;
    public GameObject sunObject;
    private Quaternion sunStartRotation;
    private Quaternion sunTargetRotation;
    private Quaternion clockStartRotation;
    private Quaternion clockTargetRotation;
    public event Action OnDayFinish;
    // Start is called before the first frame update
    void Start()
    {
        ResetDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (cycle)
        {
            timePassed += Time.deltaTime;
            float t = timePassed / dayLengthInSec;
            sunObject.transform.rotation = Quaternion.Lerp(sunStartRotation, sunTargetRotation, t);
            clockHand.transform.rotation = Quaternion.Lerp(clockStartRotation, clockTargetRotation, t);
            if (t >= 1.0f)
            {
                cycle = false; // Stop rotating
                OnDayFinish?.Invoke();
            }
        }
    }

    public void ResetDay() {
        sunStartRotation = sunObject.transform.rotation;
        sunTargetRotation = sunStartRotation * Quaternion.Euler(0, 180, 0);
        clockStartRotation = clockHand.transform.rotation;
        clockTargetRotation = clockStartRotation * Quaternion.Euler(0, 0, 180);
    }

    public void StartDay() {
        ResetDay();
        cycle = true;
        timePassed = 0;
    }
}
