using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] areaPrefabs; // ���� ������ �迭
    [SerializeField]
    private int spawnerAreaCountAtStart = 3; // ���� ���� �� ���� ���� �Ǵ� ���� ����
    [SerializeField]
    private float zDistance = -96; // ���� ������ �Ÿ�(z)
    private int areaIndex = 0; // ���� �ε��� ��ġ�Ǵ� ������ z��ġ ���꿡 ���

    [SerializeField]
    private Transform playerTransfrom; // �÷��̾� Transform

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
