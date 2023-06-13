using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int attackPower;
    public float health;
    public float maxHealth;
    public float normalSpeed;
    public float dashSpeed;
    private int posIndex;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bomb"))
        {
            if(health <= 0)
            {
                GameManager.instance.enemySpawner.spawnCount -= 1;
                anim.SetTrigger("OnDie");
            }
            health -= collision.gameObject.GetComponent<Bomb>().damage;
            anim.SetTrigger("OnHit");
            collision.gameObject.SetActive(false);
        }
    }

    private void OnDeath()
    {
        GameManager.instance.enemySpawner.spawnCount--;
        GameManager.instance.enemySpawner.posCheck[posIndex-1] = 0;
        gameObject.SetActive(false);
    }

    public void Init(SpawnData data, int idx)
    {
        attackPower = data.attackPower;
        maxHealth = data.health;
        health = maxHealth;
        normalSpeed = data.normalSpeed;
        dashSpeed = data.dashSpeed;
        posIndex = data.posIndex = idx;
    }
}
