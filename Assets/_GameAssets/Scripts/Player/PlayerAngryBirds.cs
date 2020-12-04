using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAngryBirds : MonoBehaviour
{
    public float forceScale;
    public Transform posicionInicial;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Lanzar();
        }
    }
    void Lanzar()
    {
        print("Lanzando");
        GetComponent<Rigidbody2D>().isKinematic = false;
        Vector2 direction = posicionInicial.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(direction * forceScale);

    }
    private void OnMouseDrag()
    {
        Vector3 np = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        np = new Vector3(np.x, np.y, 0); //Corregir la z
        transform.position = np;
    }

    private void OnMouseUp()
    {
        Lanzar();
    }
}

