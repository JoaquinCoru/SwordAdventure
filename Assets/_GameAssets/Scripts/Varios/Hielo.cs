using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hielo : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            collision.gameObject.GetComponent<PlayerReaction>().JumpBack();
            collision.gameObject.GetComponent<PlayerManager>().RecibirDanyo();         
            
        }
    }
}
