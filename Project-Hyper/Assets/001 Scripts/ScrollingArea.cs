using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingArea : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 4f;

    private void Update()
    {
        // 게임 오브젝트를 scrollSpeed만큼 프레임마다 일정하게 이동
        transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
    }
}
