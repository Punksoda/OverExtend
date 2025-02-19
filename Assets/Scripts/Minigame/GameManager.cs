using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;
    UIManager uiManager;

    public static UIManager UIManager
    {
        get { return UIManager; }
    }


    private void Awake()
    {
        uiManager = FindAnyObjectByType<UIManager>();

        if (gameManager == null)
        {
            gameManager = this;
            
        }
        else
        {
            if(gameManager != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }

}