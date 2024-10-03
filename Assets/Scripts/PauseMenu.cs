using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0.0f;
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
    }

    void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }
}
