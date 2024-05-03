using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    private bool gamePaused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject game;
   
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            Pause();
           
        }
       
       

    }
    public void Resume()
    {

        pauseMenu.SetActive(false);
        game.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        gamePaused = false;

    }

    public void Pause()
    {


        pauseMenu.SetActive(true);
        game.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0.5f;
        
        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
