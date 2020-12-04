using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaLlave : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    public void Explotar()
    {
        Instantiate(prefabExplosion, transform.position, transform.rotation);        
        Destroy(gameObject);
    }
}
