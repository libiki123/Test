using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
            
    }

    void Start()
    {
        Application.targetFrameRate = 40;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Test");
        ResumeGame();
    }

    public void LoadMainMenu()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
