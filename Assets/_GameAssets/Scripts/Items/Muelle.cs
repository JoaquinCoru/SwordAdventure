using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muelle : MonoBehaviour
{
    private Animator animator;
    public float fuerzaEmpuje=1;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Desplegar");
            collision.gameObject.GetComponentInChildren<Animator>().SetBool("Jumping", true);
            collision.rigidbody.AddForce(Vector2.up * fuerzaEmpuje, ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();

        }

    }

}
