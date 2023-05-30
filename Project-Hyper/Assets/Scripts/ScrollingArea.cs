using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingArea : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 4f;

    private void Update()
    {
        // ���� ������Ʈ�� scrollSpeed��ŭ �����Ӹ��� �����ϰ� �̵�
        transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
    }
}
