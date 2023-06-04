using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_Intro : MonoBehaviour
{
    public void ClickSetttingButton()
    {
        Debug.Log("설정 창 출력");
    }

    public void ClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
