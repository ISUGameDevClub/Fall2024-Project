using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_creator : MonoBehaviour
{

    public GameObject menuCanvasPrefab;
    bool menuActive = false;
   // public GameObject

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMenuActiveFalse() => menuActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (menuActive) return;
       // int count = GameObject.FindGameObjectsWithTag("menuCanvasPrefab").Length;

        //Instantiate(r_menu);
       // if (GameObject.FindGameObjectsWithTag("menuCanvasPrefab") < 1) //GameObject.FindGameObjectsWithTag ("pickup")  "menuCanvasPrefab")
        //{
        Instantiate(menuCanvasPrefab);
        menuActive = true;
        //}
        //Debug.Log(count);
    }


}
