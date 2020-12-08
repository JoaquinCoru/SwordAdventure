using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStairs : MonoBehaviour
{
    public float speed;
    public bool enEscalera = false;
    public float y;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escalera"))
        {
            enEscalera = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
            animator.SetBool("Climbing", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escalera"))
        {
            enEscalera = false;
            GetComponent<Rigidbody2D>().isKinematic = false;
            animator.SetBool("Climbing", false);
        }
    }

    private void Update()
    {
        y = Input.GetAxis("Vertical");
        if (enEscalera)
        {
            transform.Translate(Vector2.up * y * Time.deltaTime * speed);
        }        
    }
}
