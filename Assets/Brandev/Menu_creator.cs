using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_creator : MonoBehaviour
{

    public GameObject menuCanvasPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        Instantiate(menuCanvasPrefab);
    }


}
