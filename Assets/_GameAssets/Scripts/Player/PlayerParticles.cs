using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public GameObject particles;
    private Rigidbody2D rigidbody;
    float x;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rigidbody.velocity.y) < 0.01f && Mathf.Abs(x) > 0.01f)
        {
            particles.SetActive(true);
        }
        else
        {
            particles.SetActive(false);
        }
    }
}
