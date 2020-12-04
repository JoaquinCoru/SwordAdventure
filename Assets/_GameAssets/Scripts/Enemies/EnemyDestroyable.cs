using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyable : Enemy
{
    [SerializeField]
    private float fuerzaRebote;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!gameObject.CompareTag("Saw"))
            {
                ReproducirExplosion();
                collision.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.up * fuerzaRebote, ForceMode2D.Impulse);
                collision.GetComponentInParent<PlayerSoundManager>().PlayAudioDamage();
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
