using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDeslizante : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerMover>().estaDeslizando = true;          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerMover>().estaDeslizando = false;
        }
    }

}
