using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_handeler : MonoBehaviour
{
    //public GameObject confirm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void confirmation()
    {
        Debug.Log("Howdy! This is a test!");
        SceneManager.LoadScene("Test_Scene_BB");

    }

    public void decline()
    {
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
