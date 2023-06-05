using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackItemSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnDelay = 1.0f;
    private float currentTime;
    public Transform spawnPoint;

    private void Awake()
    {
        spawnPoint = transform.GetChild(0).transform;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    public void SpawnStart()
    {
        if (currentTime > spawnDelay)
        {
            currentTime = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject attackItem = GameManager.instance.pool.Get(0);
        attackItem.transform.position = spawnPoint.position;
    }
}
