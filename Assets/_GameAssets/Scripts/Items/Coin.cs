using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject flyingPoints;
    public int puntos;
    private bool saliendo = false;

    private void OnApplicationQuit()
    {
        saliendo = true;
    }

    private void OnDestroy()
    {
        if (saliendo==false)
        {
            
            GameObject fn = GameObject.Instantiate(flyingPoints, transform.position, transform.rotation);
            fn.GetComponent<FlyingPoints>().SetPoints(puntos);
        }

    }
}
