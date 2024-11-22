using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class RestStartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameObject.active = false;
        }
    }

    // Update is called once per frame

    public void confirmation()
    {
        Time.timeScale = 1;
        gameObject.active = false;
        GameManager.instance.StartEndDayScene();
    }

    public void decline()
    {
        Time.timeScale = 1;
        gameObject.active = false;
    }

    public void Open() {
        Time.timeScale = 0;
        gameObject.active = true;
    }
}
