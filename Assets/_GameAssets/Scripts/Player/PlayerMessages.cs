using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMessages : MonoBehaviour
{
    private bool primeraSeñalMuerte = true;
    private bool primerCofre = true;
    private bool primerCheckPoint = true;
    private bool primeraSalida = true;
    private bool primerDiamante = true;

    private GameManager gameManager;

    private PlayerSoundManager psm;
    private void Awake()
    {
        psm = GetComponent<PlayerSoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            GameObject.Find("GameManager").GetComponent<UIManager>().MostrarMensaje("Esto es un check point para recuperar tu estado");
            primerCheckPoint = false;
            psm.PlayAudioMessage();
        }

        if (collision.gameObject.CompareTag("Exit") && primeraSalida)
        {
            if (!gameManager.hasKey)
            {
                GameObject.Find("GameManager").GetComponent<UIManager>().MostrarMensaje("Necesitas la llave para salir del nivel");
                primeraSalida = false;
                psm.PlayAudioMessage();
            }
        }

        if (collision.gameObject.CompareTag("Diamante") && primerDiamante)
        {
            if (!gameManager.hasKey)
            {
                GameObject.Find("GameManager").GetComponent<UIManager>().MostrarMensaje("Para mover algunas plataformas necesitarás activarlas con interruptores");
                primerDiamante = false;
                psm.PlayAudioMessage();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<UIManager>().OcultarMensaje();
    }

}
