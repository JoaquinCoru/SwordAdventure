using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaHundible : MonoBehaviour
{
    bool seHaIniciadoBajada = false;
    public bool estaBajando = false;
    public float speed;
    private Vector3 posicionInicial;
    public float tiempoEspera;

    private void Awake()
    {
        posicionInicial = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!seHaIniciadoBajada && collision.gameObject.CompareTag("Player"))
        {
            seHaIniciadoBajada = true;            
            Invoke("CambiarEstado", tiempoEspera);            
        }      
    }

    private void Update()
    {        
        if (estaBajando)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    private void CambiarEstado()
    {
        estaBajando = true;
       // GetComponent<Flasher>().Flash();
    }

    public void RestaurarEstadoInicial()
    {
        transform.position = posicionInicial;
        seHaIniciadoBajada = false;
        estaBajando = false;
    }

}
