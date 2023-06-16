using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager_Play : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject playCanvas;

    public GameObject pauseWindow;
    public GameObject optionWindow;
    public GameObject gameOverWindow;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverBestScoreText;

    private bool isPauseStart;
    private bool isPausePlay;

    private int score = 0;
    private int bestScore = 0;

    private int cnt = 0;

    private void Awake()
    {
        isPauseStart = true;
        isPausePlay = false;
        SetScore();
    }

    private void OnEnable()
    {
        playCanvas.gameObject.SetActive(false);
        startCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        
        if(isPauseStart == false)
        {
            if (isPausePlay == true)
            {
                Time.timeScale = 0;
            }

            if (isPausePlay == false)
            {
                Time.timeScale = 1;
            }
        }

        if(GameManager.instance.playerDamage.isDeath == true)
        {
            GameOverOff();
            GameManager.instance.soundManager.OnGameOver();
            GameManager.instance.playerDamage.isDeath = false;
            isPausePlay = true;
            Time.timeScale = 0;
        }
    }

    public void ClickPauseButton()
    {
        isPausePlay = true;
        pauseWindow.gameObject.SetActive(true);
    }

    public void ClickReplayButton()
    {
        isPausePlay = false;
        pauseWindow.gameObject.SetActive(false);
    }

    public void ClickOptionsButton()
    {
        optionWindow.gameObject.SetActive(true);
    }

    public void ClickOptionsExitButton()
    {
        optionWindow.gameObject.SetActive(false);
    }

    public void ClickStartButton()
    {
        isPauseStart = false;
        Time.timeScale = 1;
        startCanvas.gameObject.SetActive(false);
        playCanvas.gameObject.SetActive(true);
    }

    public void GameOverOff()
    {
        gameOverWindow.gameObject.SetActive(!gameOverWindow.gameObject.activeSelf);
    }

    // 스코어 관련 함수
    private void SetScore()
    {
        if (bestScore < score)
        {
            bestScore = score;
        }
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
        gameOverBestScoreText.text = bestScore.ToString();    
    }

    public void GetScore(int inputScore)
    {
        score += inputScore;
        SetScore();
    }
}
