using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour
{

    private static SoundManagerScript _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name != "CoverScene" && SceneManager.GetActiveScene().name != "LevelSelection")
        {
            Destroy(this.gameObject);
        }

    }


}
