using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Menu : MonoBehaviour
{
    int fS = 0;
    [SerializeField] TextMeshProUGUI finalScoreText;
    private void Start()
    {
        fS = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = fS.ToString();
    }
    public void LoadForstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
