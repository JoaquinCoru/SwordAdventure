using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject flyingPoints;
    private GameObject player;
    public int puntos;

    private Animator animator;
    private bool saliendo = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Espada"))
        {         

            if (saliendo == false && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name=="ChestClosed" && player.GetComponent<PlayerAttack>()._isAttacking)
            {
                animator.SetBool("Abierto", true);
                GetComponent<AudioSource>().Play();
                GameObject fn = GameObject.Instantiate(flyingPoints, transform.position, transform.rotation);
                fn.GetComponent<FlyingPoints>().SetPoints(puntos);
            }
        }
    }

    private void OnApplicationQuit()
    {
        saliendo = true;
    }
}
