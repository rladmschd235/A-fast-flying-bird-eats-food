using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObstacle : MonoBehaviour
{
    public float scrollSpeed;

    private void Update()
    {
        // 게임 오브젝트를 scrollSpeed만큼 프레임마다 일정하게 이동
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
    }
}
