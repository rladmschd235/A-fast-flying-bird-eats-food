using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // x축 이동 
    private float moveXWidth = 5f; // 1회 이동 시 이동 거리 (x축)
    private float moveTimeX = 0.1f; // 1회 이동에 소요되는 시간 (x축)
    private bool isXMove = false; // true : 이동 중, false : 이동 가능

    public LayerMask layer;
    public bool isGround = false;
    public int jumpCount = 2;

    [SerializeField]
    private float moveSpeed = -10f;
    [SerializeField]
    private float jumpHeight = 5f;

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

    public void CheckGround()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, out hit, 0.4f, layer))
        {
            jumpCount = 2;
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    public void OnJump()
    {
        Vector3 jumpPower = Vector3.up * jumpHeight;
        rigid.AddForce(jumpPower, ForceMode.VelocityChange);
        jumpCount--;
    }
}
