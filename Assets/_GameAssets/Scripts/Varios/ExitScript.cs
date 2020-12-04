using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    [Header("Nombre de la siguiente escena")]
    [SerializeField]
    private string sceneName;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameManager.hasKey)
            {
                gameManager.GuardarPuntuacionNivel();
                if (SceneManager.GetActiveScene().name == "Scene2")
                {
                    GameStatusManager.Instance.SetNumeroVidas(0);
                    GameStatusManager.Instance.SetPuntuacion(0);//STATUS DEL JUEGO CUANDO SE TERMINA
                }
                 SceneManager.LoadScene(sceneName);
            }
        }
    }
}
