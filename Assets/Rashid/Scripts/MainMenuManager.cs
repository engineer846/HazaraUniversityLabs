using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    public Text HighScoreText;
    float score = 0;

    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 10);
            Debug.Log("High Score : " + PlayerPrefs.GetInt("HighScore"));
        }

        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");


    }

    private void Update()
    {
        if (isGameOver)
            return;
        score += Time.deltaTime;
        Debug.Log(score);

        if(score > PlayerPrefs.GetInt("HighScore") + 1)
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
            isGameOver = true;
        }
    }

    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }
}
