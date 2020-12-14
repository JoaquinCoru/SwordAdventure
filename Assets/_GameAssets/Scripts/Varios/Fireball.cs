using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private PlayerAttack pa;

    private void Awake()
    {
        pa = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy>().ReproducirExplosion();
                Destroy(collision.transform.parent.gameObject);
            }

            if (collision.CompareTag("Player"))
            {
            collision.gameObject.GetComponent<PlayerReaction>().JumpBack();
            collision.gameObject.GetComponent<PlayerManager>().RecibirDanyo();
            }

            if (!collision.CompareTag("ZonaDeteccion") && !collision.CompareTag("Espada"))
            {
                Destroy(gameObject);
            }

        if (collision.CompareTag("Espada") && pa._isAttacking)
        {
            float x = -GetComponent<Rigidbody2D>().velocity.x;
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0);

        }

    }

}
