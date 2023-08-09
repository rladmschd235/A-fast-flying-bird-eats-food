using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    public EnemySpawner enemySpawner;
    public UIManager_Play UIManager_Play;
    public PlayerDamage playerDamage;
    public SoundManager soundManager;
    public SceneFader sceneFader;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }
}
