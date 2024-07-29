using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameEndDoor : MonoBehaviour
{
    public Animator transition;
    [SerializeField] float LevelLoadDelay = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadWinMenu());
    }

    IEnumerator LoadWinMenu()
    {
        transition.SetTrigger("Start"); //Starting level changing Animation
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int score = FindObjectOfType<GameSession>().GetFinalScore();
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
        Destroy(gameObject);
        SceneManager.LoadScene(4);
    }
}
