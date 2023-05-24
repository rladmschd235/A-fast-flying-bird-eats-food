using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // x축 이동 
    private float moveXWidth = 5f; // 1회 이동 시 이동 거리 (x축)
    private float moveTimeX = 0.1f; // 1회 이동에 소요되는 시간 (x축)
    private bool isXMove = false; // true : 이동 중, false : 이동 가능

    // y축 이동 
    private float originY = 3f; // 착지하는 y축 값
    private float gravity = -9.81f; // 중력
    private float moveTimeY = 0.3f; // 1회 이동에 소요되는 시간 (y축)
    private bool isJump = false; // true : 점프 중, false : 점프 가능

    [SerializeField]
    private float moveSpeed = -10f;

    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }
    
    public void MoveToX(int x)
    {
        // 현재 x축 이동 중으로 이동 불가능
        if (isXMove == true) return;

        if(x > 0 && transform.position.x < moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }
        else if(x < 0 && transform.position.x > -moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }
    }

    public void MoveToY()
    {
        if (isJump == true) return;
        StartCoroutine(OnMoveToY());
    }

    IEnumerator OnMoveToX(int direction)
    {
        float current = 0;
        float percent = 0;
        float start = transform.position.x;
        float end = transform.position.x + direction * moveXWidth;

        isXMove = true;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeX;

            float x = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            yield return null;
        }

        isXMove = false;
    }

    IEnumerator OnMoveToY()
    {
        float current = 0;
        float persent = 0;
        float v0 = -gravity;

        isJump = true;
        //rigid.useGravity = false;

        while (persent < 1)
        {
            current += Time.deltaTime;
            persent = current / moveTimeY;

            // 시간 경과에 따라 오브젝트의 y위치를 바꿔준다.
            // 포물선 운동 : 시작 위치 + 초기 속도 + 시간 + 중력 * 시간 제곱
            float y = originY + (v0 * persent) + (gravity * persent * persent);
            transform.position = new Vector3(transform.position.x, y * 2f,transform.position.z);

            yield return null;
        }

        isJump = false;
        //rigid.useGravity = true;
    }
}
