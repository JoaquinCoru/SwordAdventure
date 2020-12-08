﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientator : MonoBehaviour
{
    public FixedJoystick vJoystick;
    float x;


    private void Awake()
    {
        //Asignación del VIRTUAL JOYSTICK
        if (GameObject.Find("Fixed Joystick") != null)
        {
            vJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        }
        
    }
    void Update()
    {
        if (vJoystick!=null && vJoystick.isActiveAndEnabled)
        {
            x = vJoystick.Horizontal;
        }
        else
        {
            x = Input.GetAxis("Horizontal");
        }       
       
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localPosition = new Vector3(0,0,0);
            
        } else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localPosition = new Vector3(-0.167f, 0,0);
        }
    }
}
