using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObstacle : MonoBehaviour
{
    public float scrollSpeed;

    private void Update()
    {
        // ���� ������Ʈ�� scrollSpeed��ŭ �����Ӹ��� �����ϰ� �̵�
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
    }
}
