using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float dragDistance = 100f; // 드래그 거리
    private Vector3 touchStart; // 터치 시작 위치
    private Vector3 touchEnd; // 터치 종료 위치 

    private bool isMobile = false;
    private bool isPC = false;

    // public bool isGround = false; // true : 땅에 닿아있을 때, false : 점프 중일 때
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
        // 현재 화면을 터치하고 있지 않으면 메소드 종료
        if (Input.touchCount == 0) return;

        // 첫 번째 터치 정보 불러오기
        Touch touch = Input.GetTouch(0);

        // 터치 시작 
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
            // 터치 상태로 x축 드래그 범위가 dragDistance보다 클 때
            StartCoroutine(DragXY());
        }
    }

    private void OnPCPlatform()
    {
        // 터치 시작
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
            // 터치 상태로 x축 드래그 범위가 dragDistance보다 클 때
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
        //        Debug.Log("실행해줘요...");
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
    //        Debug.Log("땅");
    //    }
    //    else
    //    {
    //        isGround = false;
    //    }
    //}
}
