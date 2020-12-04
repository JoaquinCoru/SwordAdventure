using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private GameManager gameManager;
    PlayerSoundManager psm;
    public float duracionInvencible;
    public GameObject prefabInvencible;
  
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        psm = GetComponent<PlayerSoundManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            psm.PlayAudioKey();
            GameObject.Find("GameManager").GetComponent<GameManager>().RecogerLLave();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            StartCoroutine("IniciarInvencibilidad");
        }
    }

    public void RecibirDanyo()
    {
        if (gameManager.godMode==false)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().QuitarVida();
            psm.PlayAudioDamage();
            GetComponent<Flasher>().Flash(); //Llamada al Flasher para que parpadee
        }    
    }

    IEnumerator IniciarInvencibilidad()
    {
        psm.PlayAudioInvencible();
        gameManager.godMode = true;
        GameObject aura=Instantiate(prefabInvencible, transform.position, transform.rotation);
        aura.transform.SetParent(transform);
        yield return new WaitForSeconds(duracionInvencible);
        Destroy(aura);
        gameManager.godMode = false;
        psm.PlayLevelMusic();
    }


}
