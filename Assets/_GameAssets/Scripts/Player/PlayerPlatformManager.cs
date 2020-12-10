using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformManager : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Adherente"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.SetParent(null);
    }

}
