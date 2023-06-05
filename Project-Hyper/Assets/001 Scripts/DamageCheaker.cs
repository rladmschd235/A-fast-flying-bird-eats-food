using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCheaker : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Rock"))
        {
            anim.SetTrigger("OnHit");
            collision.gameObject.SetActive(false);
        }
    }
}
