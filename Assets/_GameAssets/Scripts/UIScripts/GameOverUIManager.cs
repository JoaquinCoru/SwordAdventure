using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{


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
}
