using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public SpawnData[] spawnData;

    private float currentTime;
    public int spawnCount = 0;
    public float spawnTime;

    public int[] posCheck = new int[3];
    
    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(spawnCount < 3)
        {
            if (currentTime > spawnTime)
            {
                currentTime = 0;
                Spawn(RandomEnemyType());
                Debug.Log(spawnCount);
                spawnCount++;
            }
        }
    }

    private int RandomEnemyType()
    {
        int enemyType = Random.Range(1, 4);
        return enemyType;
    }

    private int RandomPosition()
    {
        int pos = Random.Range(1, 4);
        if (posCheck[0] > 0 && posCheck[1] > 0 && posCheck[2] > 0)
        {
            return -1;
        }
        if (posCheck[pos-1] == 0)
        {
            posCheck[pos-1]++;
            return pos;
        }
        return RandomPosition();
    }

    private void Spawn(int enemyType)
    {
        //enemy.transform.position = spawnPoints[posType].position;
        int posIdx = RandomPosition();
        if (posIdx == -1)
        {
            RandomPosition(); // 전부 몬스터가 있을 경우
        }
        else
        {
            GameObject enemy = GameManager.instance.pool.Get(enemyType);
            enemy.transform.position = spawnPoints[posIdx].position;
            enemy.GetComponent<Enemy>().Init(spawnData[enemyType - 1], posIdx);
        }  
    }
}

[System.Serializable]
public class SpawnData
{
    public int attackPower;
    public int health;
    public float normalSpeed;
    public float dashSpeed;
    public int posIndex;
}
