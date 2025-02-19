using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameStartText;

    public void Start()
    {
        GameManager.Instance.UIManager = this; // ���ӸŴ����� �Ǿ��ִ� UI �Ŵ��� ����

        if(gameStartText == null) // �� üũ
        {
            Debug.LogError("GameStart is null");
        }
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}