using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Play : MonoBehaviour
{
    public GameObject pauseWindow;

    private void Update()
    {
        
    }

    public void ClickPauseButton()
    {
        pauseWindow.gameObject.SetActive(true);
    }

    public void ClickReplayButton()
    {
        pauseWindow.gameObject.SetActive(false);
    }
}
