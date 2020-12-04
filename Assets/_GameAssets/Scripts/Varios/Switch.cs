using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Animator animator;
    private GameObject cajaLlave;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        cajaLlave = GameObject.Find("CajaLlave");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Weight")
        {
            animator.SetBool("Activar", true);
            cajaLlave.GetComponent<CajaLlave>().Explotar();
            GetComponent<AudioSource>().Play();
        }
    }
}
