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
        panel.gameObject.SetActive(true); // �ǳ� Ȱ��ȭ
        float fadeCount = 0; // ó�� ���� ��
        while(fadeCount < 1.0f) // ���� �ִ� �� 1.0���� �ݺ�
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f); // 0.01�� ���� ����
            panel.color = new Color(0, 0, 0, fadeCount); // ���� ������ ���� �� ����
        }
        SceneManager.LoadScene("PlayScene");
    }
}
