using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public  bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject cheatUI;
    // Update is called once per frame
    void Update()
    {
        
        if (GvrControllerInput.AppButtonDown){
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        FindObjectOfType<MusicManager>().Play("click");
        pauseMenuUI.SetActive(false);
        cheatUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        FindObjectOfType<MusicManager>().Play("click");
        pauseMenuUI.SetActive(true);
        cheatUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("back to Start");
        SceneManager.LoadScene("CallMenu");
    }

    public void QuitGame()
    {
        FindObjectOfType<MusicManager>().Play("click");
        Debug.Log("Quit");
        Application.Quit();
    }
}
