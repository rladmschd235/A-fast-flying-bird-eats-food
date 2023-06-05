using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 발판을 주기적으로 재배치 해주는 스크립트
public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    public int count = 8; // 첫 생성 area 개수
    public GameObject areaPrefabs; // 생성할 발판의 원본 프리팹

    private GameObject[] areas; // 미리 생성한 area들

    [SerializeField]
    private float zDistance = 12f;
    private Vector3 spawnPosition = Vector3.zero;

    private void Awake()
    {
        areas = new GameObject[count];

        for(int index = 0; index < count; index++)
        {
            areas[index] = Instantiate(areaPrefabs);
            areas[index].transform.position = new Vector3(0, 0, index * zDistance);
        }
    }
}
