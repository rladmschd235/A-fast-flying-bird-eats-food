using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] areaPrefabs; // 구역 프리팹 배열
    [SerializeField]
    private int spawnerAreaCountAtStart = 3; // 게임 시작 시 최초 생성 되는 구역 개수
    [SerializeField]
    private float zDistance = -96; // 구역 사이의 거리(z)
    private int areaIndex = 0; // 구역 인덱스 배치되는 구역의 z위치 연산에 사용

    [SerializeField]
    private Transform playerTransfrom; // 플레이어 Transform

    private void Awake()
    {
        for(int i = 0; i < spawnerAreaCountAtStart; ++i)
        {
            if(i == 0)
            {
                SpawnArea(false);
            }
            else
            {
                SpawnArea();
            }
        }
    }

    public void SpawnArea(bool isRandom = true)
    {
        GameObject clone = null;

        if(isRandom == false)
        {
            clone = Instantiate(areaPrefabs[0]);
        }
        else
        {
            int index = Random.Range(0, areaPrefabs.Length);
            clone = Instantiate(areaPrefabs[index]);
        }

        clone.transform.position = new Vector3(0, 0, areaIndex * zDistance);

        clone.GetComponent<Area>().Setup(this, playerTransfrom);

        areaIndex++;
    }
}
