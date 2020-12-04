using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{

    private PlayerSoundManager psm;

    private void Awake()
    {
        psm = GetComponent<PlayerSoundManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            psm.PlayAudioCoin();
            int puntos = collision.gameObject.GetComponentInParent<Coin>().puntos;
            GameObject.Find("GameManager").GetComponent<GameManager>().IncrementarPuntuacion(puntos);           
           
            Destroy(collision.transform.parent.gameObject);                 
           
        }
    }

}
