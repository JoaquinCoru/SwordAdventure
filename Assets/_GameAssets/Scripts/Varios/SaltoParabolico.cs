using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoParabolico : MonoBehaviour
{
    [Range(0, 1f)]
    public float speed;
    [Range(0, 10)]
    public float frecuencia;
    [Range(1, 10)]
    public float amplitud;
    private void Start()
    {
        StartCoroutine("SaltaZigZag");
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    print("R");
        //    StartCoroutine("SaltaHaciaLaDerecha");
        //}         
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    print("L");
        //    StartCoroutine("SaltaHaciaLaIzquierda");
        //}
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    print("Z");
        //    StartCoroutine("SaltaZigZag");
        //}
    }
    IEnumerator SaltaZigZag()
    {
        float x, y;
        Vector3 nuevaPosicion;
        while (true)
        {
            x = transform.position.x;
            y = transform.position.y;
            for (float i = 0; i <= Mathf.PI; i += speed)
            {
                nuevaPosicion = SetNuevaPosicion(x, y, i, 1);
                yield return new WaitForSeconds(0.016f);
            }
            transform.position = new Vector3(transform.position.x, y, 0);
            x = transform.position.x;
            y = transform.position.y;
            for (float i = 0; i <= Mathf.PI; i += speed)
            {
                nuevaPosicion = SetNuevaPosicion(x, y, i, -1);
                yield return new WaitForSeconds(0.016f);
            }
            transform.position = new Vector3(transform.position.x, y, 0);
        }
    }
    IEnumerator SaltaHaciaLaDerecha()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Vector3 nuevaPosicion;
        for (float i = 0; i <= Mathf.PI; i+=speed)
        {
            nuevaPosicion = SetNuevaPosicion(x, y, i, 1);
            yield return new WaitForSeconds(0.016f);
        }
        transform.position = new Vector3(transform.position.x, y, 0);
    }
    IEnumerator SaltaHaciaLaIzquierda()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Vector3 nuevaPosicion;
        for (float i = 0; i <= Mathf.PI; i += speed)
        {
            nuevaPosicion = SetNuevaPosicion(x, y, i, -1);
            yield return new WaitForSeconds(0.016f);
        }
        transform.position = new Vector3(transform.position.x, y, 0);
    }
    private Vector3 SetNuevaPosicion(float x, float y, float i, int multiplicador)
    {
        Vector3 nuevaPosicion = new Vector3(
                        x + ((i * frecuencia) * multiplicador),
                        y + (Mathf.Sin(i) * amplitud),
                        0
                    );
        transform.position = nuevaPosicion;
        return nuevaPosicion;
    }
}
