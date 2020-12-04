using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    [SerializeField]
    private GameObject prefabExplosion;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            if (!gameObject.CompareTag("Saw") && gameManager.godMode)
            {
                ReproducirExplosion();
                Destroy(transform.parent.gameObject);
                return;
            }

            collision.gameObject.GetComponent<PlayerReaction>().JumpBack();
            collision.gameObject.GetComponent<PlayerManager>().RecibirDanyo();         
            
        }
    }

    public void ReproducirExplosion()
    {
        Instantiate(prefabExplosion, transform.position, transform.rotation);
    }
}
