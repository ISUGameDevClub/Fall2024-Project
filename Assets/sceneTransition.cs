using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //LoadNextLevel();
            PlayerDeathTransition();
        }
        if (Input.GetKeyDown(KeyCode.Tab)) {
            LoadLevelIndex(0);
        }
    }

    public void LoadLevelIndex(int levelIndex)
    {
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(LoadLevel(levelIndex));
    }

    public void PlayerDeathTransition() {
        transition.SetTrigger("DeathFade");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(levelIndex);

    }
}
