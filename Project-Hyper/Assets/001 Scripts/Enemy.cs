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

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Rock"))
        {
            health -= collision.gameObject.GetComponent<Rock>().damage;
            anim.SetTrigger("OnHit");
            collision.gameObject.SetActive(false);
        }
    }

    public void Init(SpawnData data)
    {
        attackPower = data.attackPower;
        maxHealth = data.health;
        health = maxHealth;
        normalSpeed = data.normalSpeed;
        dashSpeed = data.dashSpeed;
    }
}
