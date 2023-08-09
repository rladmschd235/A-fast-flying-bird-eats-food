using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float dragDistance = 100f; // �巡�� �Ÿ�
    private Vector3 touchStart; // ��ġ ���� ��ġ
    private Vector3 touchEnd; // ��ġ ���� ��ġ 

    private bool isMobile = false;
    private bool isPC = false;

    // public bool isGround = false; // true : ���� ������� ��, false : ���� ���� ��
    // public int jumpCount = 2;
    public float dragDelay = 0.5f;

    private PlayerMovement movement;
    
    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Application.isMobilePlatform)
        {
            OnMobilePlatform();
        }
        else
        {
            OnPCPlatform();
        }
    }

    private void OnMobilePlatform()  
    {
        // ���� ȭ���� ��ġ�ϰ� ���� ������ �޼ҵ� ����
        if (Input.touchCount == 0) return;

        // ù ��° ��ġ ���� �ҷ�����
        Touch touch = Input.GetTouch(0);

        // ��ġ ���� 
        if (touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }
        else if(touch.phase == TouchPhase.Moved)
        {
            touchEnd = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            // ��ġ ���·� x�� �巡�� ������ dragDistance���� Ŭ ��
            StartCoroutine(DragXY());
        }
    }

    private void OnPCPlatform()
    {
        // ��ġ ����
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ��ġ ���·� x�� �巡�� ������ dragDistance���� Ŭ ��
            StartCoroutine(DragXY());
        }
    }

    IEnumerator DragXY()
    {
        if (Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance)
        {
            movement.MoveToX((int)Mathf.Sign(touchEnd.x - touchStart.x));
            yield return new WaitForSeconds(dragDelay);
        }
        
        //if (Mathf.Abs(touchEnd.y - touchStart.y) >= dragDistance)
        //{
        //    if (jumpCount > 0)
        //    {
        //        Debug.Log("���������...");
        //        movement.OnJump();
        //        jumpCount--;
        //        yield return new WaitForSeconds(dragDelay);
        //    }
        //}
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        jumpCount = 2;
    //        isGround = true;
    //        Debug.Log("��");
    //    }
    //    else
    //    {
    //        isGround = false;
    //    }
    //}
}
