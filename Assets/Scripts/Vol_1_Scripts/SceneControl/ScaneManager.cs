using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaneManager : MonoBehaviour
{

    private int nextSceneIndex;
    private int previousSceneIndex;

    private void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadPreviousScene()
    {
        // Sahnenin en ba��nda de�ilsek, �nceki sahneyi y�kle
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }
}

