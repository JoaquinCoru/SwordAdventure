using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    private string frase = "GAME OVER";
    private Text texto;
    void Start()
    {
        texto = GetComponent<Text>();
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        foreach(char caracter in frase)
        {
            texto.text += caracter;
            yield return new WaitForSeconds(0.3f);
        }
    }

}
