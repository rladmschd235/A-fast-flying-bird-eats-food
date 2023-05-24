using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // x�� �̵� 
    private float moveXWidth = 5f; // 1ȸ �̵� �� �̵� �Ÿ� (x��)
    private float moveTimeX = 0.1f; // 1ȸ �̵��� �ҿ�Ǵ� �ð� (x��)
    private bool isXMove = false; // true : �̵� ��, false : �̵� ����

    // y�� �̵� 
    private float originY = 3f; // �����ϴ� y�� ��
    private float gravity = -9.81f; // �߷�
    private float moveTimeY = 0.3f; // 1ȸ �̵��� �ҿ�Ǵ� �ð� (y��)
    private bool isJump = false; // true : ���� ��, false : ���� ����

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
        // ���� x�� �̵� ������ �̵� �Ұ���
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

            // �ð� ����� ���� ������Ʈ�� y��ġ�� �ٲ��ش�.
            // ������ � : ���� ��ġ + �ʱ� �ӵ� + �ð� + �߷� * �ð� ����
            float y = originY + (v0 * persent) + (gravity * persent * persent);
            transform.position = new Vector3(transform.position.x, y * 2f,transform.position.z);

            yield return null;
        }

        isJump = false;
        //rigid.useGravity = true;
    }
}
