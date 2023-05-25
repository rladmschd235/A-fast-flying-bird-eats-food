using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float dragDistance = 50f; // 드래그 거리
    private Vector3 touchStart; // 터치 시작 위치
    private Vector3 touchEnd; // 터치 종료 위치 

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
        // 현재 화면을 터치하고 있지 않으면 메소드 종료
        if (Input.touchCount == 0) return;

        // 첫 번째 터치 정보 불러오기
        Touch touch = Input.GetTouch(0);

        // 터치 시작 
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
        // 터치 시작
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        // 터치 & 드래그
        else if (Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            OnDragXY();
        }
    }

    private void OnDragXY()
    {
        // 터치 상태로 x축 드래그 범위가 dragDistance보다 클 때
        if(Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance)
        {
            movement.MoveToX((int)Mathf.Sign(touchEnd.x - touchStart.x));
            return;
        }

        if(touchEnd.y - touchStart.y >= dragDistance)
        {
            // 점프 실행
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
