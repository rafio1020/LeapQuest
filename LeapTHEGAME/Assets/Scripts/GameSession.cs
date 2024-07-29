using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] int previousLevelScore = 0;
    private static int finalScore = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    private void Awake()
    {
        int numOfGameSession = FindObjectsOfType<GameSession>().Length;
        if(numOfGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        livesText.text=playerLives.ToString();
        scoreText.text=score.ToString();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text=score.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    public void WinPlayer()
    {
        ResetGameSession();
    }
    private void ResetGameSession()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
        Destroy(gameObject);
        SceneManager.LoadScene(4);
        FindObjectOfType<AudioManager>().Play("gover");

    }

    private void TakeLife()
    {
        playerLives--;

        score = previousLevelScore;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
        scoreText.text = score.ToString();
        livesText.text = playerLives.ToString();
    }
    public int GetScore()
    {
        return score;
    }
    public void SaveScoreBeforeLoadingNextLevel()
    {
        previousLevelScore = score;
    }
    public int GetFinalScore()
    {
        return finalScore;
    }
}
