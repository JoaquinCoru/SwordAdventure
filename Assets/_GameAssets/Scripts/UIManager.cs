using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image imagenLlave;
    public Text puntuacion;

    private void Awake()
    {
        puntuacion = GameObject.Find("TextScore").GetComponent<Text>();
        imagenLlave = GameObject.Find("ImageKeyOn").GetComponent<Image>();
    }

    public void CrearVidasUI(int numeroVidas, GameObject prefabImagenVida,GameObject panelVidas)
    {
        LimpiarPanel(panelVidas);
        for (int i = 0; i < numeroVidas; i++)
        {
            GameObject nuevaImagenVida = Instantiate(prefabImagenVida, transform.position, transform.rotation);
            nuevaImagenVida.transform.SetParent(panelVidas.transform);
            nuevaImagenVida.transform.localScale = Vector3.one;
        }
    }

    private void LimpiarPanel(GameObject panelVidas)
    {
        foreach (Transform child in panelVidas.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ActivarLlave()
    {
        imagenLlave.enabled = true;
    }

    public void SetPuntuacion(int points)
    {
        puntuacion.text = points.ToString();
    }


}
