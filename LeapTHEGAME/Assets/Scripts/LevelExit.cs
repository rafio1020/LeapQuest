using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Animator transition;
    int getBackScore = 0;
    [SerializeField] float LevelLoadDelay = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            StartCoroutine(LoadNextLevel());
        }
        else
        {
            StartCoroutine(WinLevel());
        }
        
    }

    IEnumerator WinLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(LevelLoadDelay);
        FindObjectOfType<GameSession>().WinPlayer();
    }

    IEnumerator LoadNextLevel()
    {
        FindObjectOfType<GameSession>().SaveScoreBeforeLoadingNextLevel();
        transition.SetTrigger("Start"); //Starting level changing Animation
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public int getScoreFromLevel()
    {
        return getBackScore;
    }
}
