using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    private bool primerMensaje = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && primerMensaje)
        {
            animator.SetBool("Checked", true);
            GameObject.Find("GameManager").GetComponent<GameManager>().GuardarEstado();
            GameObject.Find("GameManager").GetComponent<UIManager>().MostrarMensaje("Esto es un check point para recuperar tu estado");
            primerMensaje = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().OcultarMensaje();

        }
    }
}
