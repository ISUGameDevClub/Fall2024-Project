using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int levelNumber)
    {
        switch (levelNumber)
        {
            case 0:
                SceneManager.LoadScene("MainMenu");
                break;
            case 1:
                SceneManager.LoadScene("World1");
                break;
            case 2:
                SceneManager.LoadScene("World2");
                break;
            case 3:
                SceneManager.LoadScene("World3");
                break;
            case 4:
                SceneManager.LoadScene("World4");
                break;
            case 5:
                SceneManager.LoadScene("Credits");
                break;
            default:
                Debug.Log("Level not found");
                break;
        }
    }
}
