using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �ֱ������� ���ġ ���ִ� ��ũ��Ʈ
public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    public int count = 8; // ù ���� area ����
    public GameObject areaPrefabs; // ������ ������ ���� ������

    private GameObject[] areas; // �̸� ������ area��

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
