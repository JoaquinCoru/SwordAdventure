using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private PlayerAttack pa;
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private GameObject light;

    private void Awake()
    {
        pa = GameObject.Find("Player").GetComponent<PlayerAttack>();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Espada") && pa._isAttacking )
        {
            platform.GetComponent<TwoPointsMover>().enabled = true;
            light.SetActive(true);
        }
    }
}
