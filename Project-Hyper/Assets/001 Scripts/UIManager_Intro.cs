using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_Intro : MonoBehaviour
{
    public GameObject UIComponent;
    public GameObject optionWindow;

    private void OnEnable()
    {
        Time.timeScale = 1;
    }

    private void Awake()
    {
        UIComponent.gameObject.SetActive(true);
        optionWindow.gameObject.SetActive(false);
    }

    public void ClickSetttingButton()
    {
        UIComponent.gameObject.SetActive(false);
        optionWindow.gameObject.SetActive(true);
    }

    public void ClickSetttingExitButton()
    {
        UIComponent.gameObject.SetActive(true);
        optionWindow.gameObject.SetActive(false);
    }

    public void ClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
