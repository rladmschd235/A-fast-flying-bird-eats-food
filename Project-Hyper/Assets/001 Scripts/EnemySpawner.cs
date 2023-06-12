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

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(spawnCount < 4)
        {
            if (currentTime > spawnTime)
            {
                currentTime = 0;
                Spawn(RandomEnemyType());
                spawnCount++;
            }
        }
    }

    private int RandomEnemyType()
    {
        int enemyType = Random.Range(1, 4);
        return enemyType;
    }

    private void Spawn(int enemyType)
    {
        GameObject enemy = GameManager.instance.pool.Get(enemyType);
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[enemyType - 1]);
    }
}

[System.Serializable]
public class SpawnData
{
    public int attackPower;
    public int health;
    public float normalSpeed;
    public float dashSpeed;
}
