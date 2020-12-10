using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMessages : MonoBehaviour
{
    private bool primeraSeñalMuerte = true;
    private bool primerCofre = true;
    private bool primerCheckPoint = true;

    private PlayerSoundManager psm;
    private void Awake()
    {
        psm = GetComponent<PlayerSoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death_Sign") && primeraSeñalMuerte)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().MostrarMensaje("¡Cuidado! Zona de pinchos.Sube a las plataformas");
            primeraSeñalMuerte = false;
            psm.PlayAudioMessage();
        }

        if (collision.gameObject.CompareTag("Chest") && primerCofre)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().MostrarMensaje("Para abrir los cofres utiliza tu espada");
            primerCofre = false;
            psm.PlayAudioMessage();
        }

        if (collision.gameObject.CompareTag("CheckPoint") && primerCheckPoint)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().MostrarMensaje("Esto es un check point para recuperar tu estad");
            primerCheckPoint = false;
            psm.PlayAudioMessage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<UIManager>().OcultarMensaje();
    }

}
