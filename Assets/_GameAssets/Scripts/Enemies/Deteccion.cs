using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    private Animator animator;
    private ShootingEnemy se;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        se = GetComponentInParent<ShootingEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Shooting", true);
            InvokeRepeating("Disparar", 0,2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Shooting", false);
            CancelInvoke("Disparar");
        }
    }

    private void  Disparar()
    {       
        se.Disparo();        
    }
}
