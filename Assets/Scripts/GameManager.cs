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

    public UIManager UIManager
    {
        get { return uiManager; }
        set { uiManager = value; }
    }


    private void Awake()
    {
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
        DontDestroyOnLoad(gameObject); // �ٸ� �������� gameObject�� ������ �� �ְ� ���ش�
    }

    private void Start()
    {
        Debug.Log("Game Start");
        uiManager.GameStart();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
        SceneManager.LoadScene("MainScene");
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