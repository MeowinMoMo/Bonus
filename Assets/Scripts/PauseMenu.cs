using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static  bool GamePaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
            // if ()
            // {

            // }
        }
    }


    public void Pause()
    {
        Debug.Log("Game Puased");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Restart()
    {
        Debug.Log("Restarting...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home(int sceneID)
    {
        Debug.Log("Going Home");
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
