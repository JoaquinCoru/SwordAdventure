using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    float xInitPosPlayer;
    float xInitPosCamera;
    float xCurrentPosPlayer;
    public float xOffset;
    void Start()
    {
        xInitPosPlayer = target.transform.position.x;
        xInitPosCamera = transform.position.x;
    }

    void Update()
    {
        xCurrentPosPlayer = target.transform.position.x;
        xOffset = xCurrentPosPlayer - xInitPosPlayer;
        transform.position = new Vector3(
            xInitPosCamera + xOffset, 
            transform.position.y, 
            transform.position.z);
    }
}
