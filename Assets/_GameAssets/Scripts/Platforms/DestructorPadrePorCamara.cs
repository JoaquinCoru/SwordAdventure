using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorPadrePorCamara : MonoBehaviour
{
    PlataformaHundible phs;
    private void Awake()
    {
        phs = GetComponentInParent<PlataformaHundible>();
    }
    private void OnBecameInvisible()
    {
        if (phs.estaBajando)
        {
            phs.RestaurarEstadoInicial();
        }
       
    }
}
