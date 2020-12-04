using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoverUIManager : MonoBehaviour
{
    public Button botonContinuar;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            botonContinuar.interactable = true;
        }
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadStoredGame()
    {
        string sceneName = PlayerPrefs.GetString("SceneName");
        GameManager.continueGame = true;
        SceneManager.LoadScene(sceneName);
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
