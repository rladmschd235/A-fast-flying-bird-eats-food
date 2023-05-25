using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float dragDistance = 50f; // �巡�� �Ÿ�
    private Vector3 touchStart; // ��ġ ���� ��ġ
    private Vector3 touchEnd; // ��ġ ���� ��ġ 

    private PlayerMovement movement;
    private Animator animator;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Application.isMobilePlatform)
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
        else if (touch.phase == TouchPhase.Moved)
        {
            touchEnd = touch.position;

            OnDragXY();
        }
    }

    private void OnPCPlatform()
    {
        // ��ġ ����
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        // ��ġ & �巡��
        else if (Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            OnDragXY();
        }
    }

    private void OnDragXY()
    {
        // ��ġ ���·� x�� �巡�� ������ dragDistance���� Ŭ ��
        if(Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance)
        {
            movement.MoveToX((int)Mathf.Sign(touchEnd.x - touchStart.x));
            return;
        }

        if(touchEnd.y - touchStart.y >= dragDistance)
        {
            // ���� ����
            movement.CheckGround();
            if (movement.isGround)
            {
                if (movement.jumpCount > 0)
                {
                    movement.OnJump();
                }
            }
            
            return;
        }
    }
}
