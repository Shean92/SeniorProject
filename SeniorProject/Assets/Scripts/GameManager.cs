using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public HealthManagerScript player;
    void Update() 
    {
        
        if (player.currentHealth <= 0)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
        
        if (Input.GetKeyDown("escape"))
        
        {
          Debug.Log ("button pressed");
          if (GameIsPaused)
          {
              Resume();
          } else
          {
              Pause();
          }
        }  
    }

    public int enemyKillCount;

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void QuitGame ()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
    }

    
}

