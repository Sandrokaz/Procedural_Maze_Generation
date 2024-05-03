using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Map");
        Debug.Log("Restart Game");
    }

   


    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
