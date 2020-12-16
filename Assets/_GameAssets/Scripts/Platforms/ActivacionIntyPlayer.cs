﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionIntyPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject light;

    private bool switchActivated = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && switchActivated)
        {
            GetComponentInParent<TwoPointsMover>().enabled = true;
            light.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && switchActivated)
        {
            GetComponentInParent<TwoPointsMover>().enabled = false;
            light.SetActive(false);
        }
    }

    public void Activate()
    {
        switchActivated = true;
    }
}
