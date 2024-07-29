using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    public void LoadForstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadAbout()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
