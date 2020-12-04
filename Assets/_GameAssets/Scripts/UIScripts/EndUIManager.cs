using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUIManager : MonoBehaviour
{
    private Text score1Text;
    private Text score2Text;
    private Text totalScore;
    
    [SerializeField]
    private GameObject highScore1;
    [SerializeField]
    private GameObject highScore2;

    private void Awake()
    {
        score1Text = GameObject.Find("Lvl1Score").GetComponent<Text>();
        score2Text= GameObject.Find("Lvl2Score").GetComponent<Text>();
        totalScore= GameObject.Find("TotalScore").GetComponent<Text>();
    }

    private void Start()
    {
        score1Text.text = PlayerPrefs.GetInt("Score1").ToString();
        score2Text.text = PlayerPrefs.GetInt("Score2").ToString();
        totalScore.text = (PlayerPrefs.GetInt("Score1")+ PlayerPrefs.GetInt("Score2")).ToString();

        if (PlayerPrefs.GetInt("Score1")==PlayerPrefs.GetInt("HighScore1"))
        {
            highScore1.SetActive(true);            
        }

        if (PlayerPrefs.GetInt("Score2") == PlayerPrefs.GetInt("HighScore2"))
        {
            highScore2.SetActive(true);
        }

    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("CoverScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
