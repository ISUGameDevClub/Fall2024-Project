using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNextDay() {
        sceneTransition.instance.LoadLevelIndex(2);
    }
}
