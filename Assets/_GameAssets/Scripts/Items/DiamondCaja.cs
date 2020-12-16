using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCaja : MonoBehaviour
{
    private PlayerAttack pa;
    private GameObject cajaLlave;
    [SerializeField]
    private GameObject light;
    private bool destroyed = false;

    private void Awake()
    {
        pa = GameObject.Find("Player").GetComponent<PlayerAttack>();
        cajaLlave = GameObject.Find("CajaLlave");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Espada") && pa._isAttacking && !destroyed)
        {
            cajaLlave.GetComponent<CajaLlave>().Explotar();
            GetComponent<AudioSource>().Play();
            destroyed = true;
            light.SetActive(true);
        }
    }
}
