using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private GameObject light;
    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Caja"))
        {
            animator.SetBool("Activar", true);
            platform.GetComponentInChildren<ActivacionIntyPlayer>().Activate();
            light.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}
