using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    private float currentTime;
    public float spawnTime;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > spawnTime)
        {
            currentTime = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject Obstacle = GameManager.instance.pool.Get(RandomType());
        Obstacle.transform.position = spawnPoints[RandomPos()].position;
    }

    private int RandomPos()
    {
        int pos = Random.Range(1, 4);
        return pos;
    }

    private int RandomType()
    {
        int type = Random.Range(4, 8);
        return type;
    }
}
