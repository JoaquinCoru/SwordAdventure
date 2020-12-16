using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Estado { Menu,Pause, Playing,GameOver}

    private const int TIME_TO_RELOAD = 4;

    [SerializeField]
    private bool useVJoystick;

    [Header("ESTADO DEL JUEGO")]
    public Estado estado;

    [Header("CONFIGURACION")]
    //Configuracion
    public bool soundOn=true;
    public bool musicON=true;

    [Header("ESTADO")]
    //Estado del juego
    public int puntuacion;
    public int numeroVidasMaximo;
    public int numeroVidas;

    [Header("INVENTARIO")]
    //Inventario
    public bool hasKey = false;

    [Header("POWER UPS")]
    //PowerUp
    //-->Super Velocidad
    public float superSpeedValue;
    public bool superSpeed = false;

    //-->Super Salto
    public float superJumpValue;
    public bool superJump = false;

    //-->Modo Divino
    public float godModeTime;
    public bool godMode = false;

    //UI
    [Header("CONFIGURACION UI")]
    public GameObject prefabImagenVida;
    private GameObject panelVidas;
    private GameObject txtgameOver;
    private GameObject mobileControls;

    //PLAYER
    private GameObject player;

    //INFO CONTINUE GAME
    public static bool continueGame = false;

    private void Awake()
    {
        //Obtención de referencias
        panelVidas = GameObject.Find("PanelCorazones");
        txtgameOver = GameObject.Find("TextGameOver");
        txtgameOver.SetActive(false);
        mobileControls = GameObject.Find("MobileControls");
        

        player = GameObject.Find("Player");
        puntuacion = 0;
        if (continueGame) RecuperarEstado();

        GetComponent<UIManager>().SetPuntuacion(puntuacion);
        numeroVidas = numeroVidasMaximo;
        GetComponent<UIManager>().CrearVidasUI(numeroVidas, prefabImagenVida, panelVidas);

            
        if (UseVJoystick())
        {
            mobileControls.SetActive(true);
        }
        else
        {
            mobileControls.SetActive(false);
        }
      
    }

    private void Start()
    {
        //STATUS
        if (GameStatusManager.Instance.GetNumeroVidas() > 0)
        {
            numeroVidas = GameStatusManager.Instance.GetNumeroVidas();
            GetComponent<UIManager>().CrearVidasUI(numeroVidas, prefabImagenVida, panelVidas);
            puntuacion = GameStatusManager.Instance.GetPuntuacion();
            GetComponent<UIManager>().SetPuntuacion(puntuacion);
            GuardarEstado();
        }
        //FIN DE STATUS

    }

    public void QuitarVida()
    {
        if (godMode) return;
        numeroVidas--;
        GameStatusManager.Instance.SetNumeroVidas(numeroVidas);//STATUS DEL JUEGO
        GetComponent<UIManager>().CrearVidasUI(numeroVidas, prefabImagenVida, panelVidas);

        if (numeroVidas==0)
        {
            //GameOver
            txtgameOver.SetActive(true);
            StopAllCoroutines();
            player.SetActive(false);
            Invoke(nameof(LoadGameOverScene), TIME_TO_RELOAD);
        }

    }

    public void AumentarVida()
    {
        numeroVidas++;
        numeroVidas = Mathf.Min(numeroVidas, numeroVidasMaximo);
        GetComponent<UIManager>().CrearVidasUI(numeroVidas, prefabImagenVida, panelVidas);
    }

    public void RecogerLLave()
    {
        hasKey = true;
        GetComponent<UIManager>().ActivarLlave();
    }

    public void IncrementarPuntuacion(int puntos)
    {
        puntuacion += puntos;
        GameStatusManager.Instance.SetPuntuacion(puntuacion);//STATUS DEL JUEGO
        GetComponent<UIManager>().SetPuntuacion(puntuacion);
    }

    public void GuardarEstado()
    {
        PlayerPrefs.SetInt("Score", puntuacion);
        int key = hasKey ? 1 : 0;
        PlayerPrefs.SetInt("HasKey", key);
        PlayerPrefs.SetString("SceneName",SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        PlayerPrefs.Save();
    }

    public void RecuperarEstado()
    {
        continueGame = false;
        if (PlayerPrefs.HasKey("Score"))
        {
            puntuacion = PlayerPrefs.GetInt("Score");
            if( hasKey = PlayerPrefs.GetInt("HasKey") == 1)
            {
                RecogerLLave();
            }

            player.transform.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
        }
    }

    
    public void GuardarPuntuacionNivel()
    {
        if (SceneManager.GetActiveScene().name=="Scene1")
        {
            PlayerPrefs.SetInt("Score1", puntuacion);
            if (PlayerPrefs.HasKey("HighScore1"))
            {
                if (puntuacion> PlayerPrefs.GetInt("HighScore1"))
                {
                    PlayerPrefs.SetInt("HighScore1", puntuacion);
                }
            }
            else
            {
                PlayerPrefs.SetInt("HighScore1", puntuacion);
            }
        }
        else
        {
            int puntuacion2=puntuacion- PlayerPrefs.GetInt("Score1");
            PlayerPrefs.SetInt("Score2", puntuacion2);
            if (PlayerPrefs.HasKey("HighScore2"))
            {
                if (puntuacion2 > PlayerPrefs.GetInt("HighScore2"))
                {
                    PlayerPrefs.SetInt("HighScore2", puntuacion2);
                }
            }
            else
            {
                PlayerPrefs.SetInt("HighScore2", puntuacion2);
            }
        }
        
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public bool UseVJoystick()
    {

        bool mobilePlatfomr =
            ((Application.platform == RuntimePlatform.Android)
            ||
            (Application.platform == RuntimePlatform.IPhonePlayer));
        if (mobilePlatfomr)
        {
            //En un dispositivo movil
            useVJoystick = true;
        }
        else if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            //En el resto
            useVJoystick = false;
        }
        //En el Editor de Unity
        return useVJoystick;

    }
}
