using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    public void MainMen()
    {
        SceneManager.LoadScene(0);
    }
    public void ClassicMode()
    {
        SceneManager.LoadScene(1);
    }

    public void NewYork()
    {
        SceneManager.LoadScene(2);
    }

    public void FotBall()
    {
        SceneManager.LoadScene(3);
    }

    public void Homer()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
        
    }   
}
