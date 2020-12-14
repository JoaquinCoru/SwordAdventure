using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionPlataforma : MonoBehaviour
{
    [SerializeField]
    private GameObject light;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<TwoPointsMover>().enabled = true;
            light.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<TwoPointsMover>().enabled = false;
            light.SetActive(false);
        }
    }
}
