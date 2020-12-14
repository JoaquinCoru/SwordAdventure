using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [Header("Prefab del proyectil")]
    public GameObject prefabProjectile;
    [Header("Punto de lanzamiento")]
    public Transform spawnPoint;

    [Header("Fuerza horizontal")]
    [Range(0, 1000)]
    public float horizontalForce;
    [Header("Tiempo entre disparos (ms)")]
    [Range(0, 2000)]
    public float timeBetweenFire;



    public void  Disparo()
    {
        float direction = spawnPoint.transform.parent.transform.localScale.x;
        GameObject projectile = Instantiate(prefabProjectile, spawnPoint.position, spawnPoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce * direction, 0));
               
    }

 
}
