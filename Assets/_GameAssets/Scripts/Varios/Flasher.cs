using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasher : MonoBehaviour
{
    [Range(0,100)]
    public int rate;
    [Range(0, 1)]
    public float delay;

    private Renderer renderer;
    private GameManager gm;
    void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        gm= GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Flash()
    {
        StartCoroutine("FlashCoroutine");
    }

    IEnumerator FlashCoroutine()
    {
        gm.godMode = true;
        for (int i = 0; i < rate; i++)
        {           
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(delay);           
        }
        renderer.enabled = true;
        gm.godMode = false;
    }
}
