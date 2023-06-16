using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public bool isDeath = false;
    private Animator anim;

    private void OnEnable()
    {
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            anim.SetTrigger("OnDie");
        }
    }

    private void OnDeath()
    {
        isDeath = true;
        gameObject.SetActive(false);
    }
}
