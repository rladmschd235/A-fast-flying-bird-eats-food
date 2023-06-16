using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image panel;

    public void FadeIn(int sceneIndex)
    {
        StartCoroutine(FadeCoroutine(sceneIndex));
    }

    IEnumerator FadeCoroutine(int sceneIndex)
    {
        panel.gameObject.SetActive(true); // 판넬 활성화
        float fadeCount = 0; // 처음 알파 값
        print(fadeCount);
        print("start out while");
        while(fadeCount < 1.0f) // 알파 최대 값 1.0까지 반복
        {
            print("in while");
            fadeCount += 0.02f;
            yield return new WaitForSecondsRealtime(0.01f); // 0.01초 마다 실행
            panel.color = new Color(0, 0, 0, fadeCount); // 변수 값으로 알파 값 지정
        }
        print("end out while");
        
        if(sceneIndex == 0)
        {
            SceneManager.LoadScene("PlayScene");
        }
        else if(sceneIndex == 1)
        {
            SceneManager.LoadScene("IntroScene");
        }
    }
}
