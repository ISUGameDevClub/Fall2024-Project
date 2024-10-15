using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightCycle : MonoBehaviour
{
    private float tempSec = 0;
    private float sec = 0;
    private float min = 0;
    private float hour = 0;
    private string clock = "";
    private bool cycle = true;
    private float speed = 86400;
    public int dayLengthInSec = 300;
    public TMP_Text textTime;
    // Start is called before the first frame update
    void Start()
    {
        speed = speed / dayLengthInSec;
    }

    // Update is called once per frame
    void Update()
    {
        if (cycle)
        {
            tempSec += Time.deltaTime;
            if (tempSec >= 1)
            {
                transform.Rotate(.00416667f * speed, 0, 0);
                sec += speed;
                tempSec = 0;
            }
            if (sec >= 60) { min += 1; sec = sec - 60f; }
            if (min >= 60) { hour += 1; min = min - 60f; }
            if (hour >= 12) { hour = 0; }

            if (hour < 10) { clock = "Time: 0" + hour + ":"; }
            else { clock = "Time: " + hour + ":"; }
            if (min < 10) { textTime.text = clock + "0" + min; }
            else { textTime.text = clock + min; }
        }
    }
}
