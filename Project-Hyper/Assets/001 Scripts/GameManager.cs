using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    public EnemySpawner enemySpawner;
    public UIManager_Play UIManager_Play;

    private void Awake()
    {
        instance = this;
    }
}
