using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour
{
    private Text textScore1;
    private Text textScore2;
    public Button level2;

    private void Awake()
    {
        textScore1 = GameObject.Find("TextScore1").GetComponent<Text>();
        textScore2 = GameObject.Find("TextScore2").GetComponent<Text>();

        
        textScore1.text = PlayerPrefs.GetInt("HighScore1").ToString();
        textScore2.text = PlayerPrefs.GetInt("HighScore2").ToString();

        if (PlayerPrefs.HasKey("Score1"))
        {
            level2.interactable = true;
        }
       
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadScene2()
    {
        //Si se elige el nivel 2 no se puntúa el nivel 1
        PlayerPrefs.SetInt("Score1", 0);
        SceneManager.LoadScene("Scene2");
    }

    public void LoadCoverScene()
    {
        SceneManager.LoadScene("CoverScene");
    }
}
