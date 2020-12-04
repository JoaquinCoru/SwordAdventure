using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            if (collision.CompareTag("EnemigoDestruible"))
            {
                collision.GetComponent<Enemy>().ReproducirExplosion();
                Destroy(collision.transform.parent.gameObject);

            }
            Destroy(gameObject);
        }

    }
}
