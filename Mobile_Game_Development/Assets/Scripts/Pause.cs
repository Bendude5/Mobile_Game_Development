using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public bool isPaused;

    private void Start()
    {
        //Disables the pause menu at the start
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        isPaused = false;
    }

    public void pauseGame()
    {
        //Activates the pause object and freezes the game
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        isPaused = true;
    }

    public void unPauseGame()
    {
        //Deactivates the pause object and unfreezes the game
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        isPaused = false;
    }
}
