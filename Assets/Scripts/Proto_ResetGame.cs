using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proto_ResetGame : MonoBehaviour
{
    KeyCode resetKey = KeyCode.R;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(resetKey)){
            resetScene();
        }
    }

    public void resetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
