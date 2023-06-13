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
        panel.gameObject.SetActive(true); // �ǳ� Ȱ��ȭ
        float fadeCount = 0; // ó�� ���� ��
        print(fadeCount);
        while(fadeCount < 1.0f) // ���� �ִ� �� 1.0���� �ݺ�
        {
            fadeCount += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f); // 0.01�� ���� ����
            panel.color = new Color(0, 0, 0, fadeCount); // ���� ������ ���� �� ����
        }
        
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
