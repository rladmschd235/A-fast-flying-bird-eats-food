using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image panel;

    public void FadeIn()
    {
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        panel.gameObject.SetActive(true); // 판넬 활성화
        float fadeCount = 0; // 처음 알파 값
        while(fadeCount < 1.0f) // 알파 최대 값 1.0까지 반복
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f); // 0.01초 마다 실행
            panel.color = new Color(0, 0, 0, fadeCount); // 변수 값으로 알파 값 지정
        }
        SceneManager.LoadScene("PlayScene");
    }
}
