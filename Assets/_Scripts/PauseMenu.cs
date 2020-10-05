using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject statsUI;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused) 
            { 
                ResumeGame();
            } 
            else PauseGame();
        }
    }


    public void PauseGame()
    {
        // display pause ui
        pauseMenuUI.SetActive(true);

        // disable stats ui
        statsUI.SetActive(false);

        // stop time    
        Time.timeScale = 0;

        // disable player controls

        isPaused = true;
    }

    public void ResumeGame()
    {
        // display pause ui
        pauseMenuUI.SetActive(false);

        // enable stats ui
        statsUI.SetActive(true);

        // stop time    
        Time.timeScale = 1;

        // disable player controls
        isPaused = false;
    }
}
