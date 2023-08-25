using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HighscoreScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highscoreText;

    void UpdateHighscore()
    {
        PlayerPrefs.SetFloat("highscore", ScoreKeeper.currentTimer);
        PlayerPrefs.Save();
    }

    void Start()
    {
        if (ScoreKeeper.currentTimer == 0)
        {
            return;
        }


        if (PlayerPrefs.HasKey("highscore"))
        {
            if (ScoreKeeper.currentTimer < PlayerPrefs.GetFloat("highscore"))
            {
                UpdateHighscore();
            }
        }
        else
        {
            UpdateHighscore();
        }

        int minutes = Mathf.FloorToInt(PlayerPrefs.GetFloat("highscore") / 60);
        int seconds = Mathf.FloorToInt(PlayerPrefs.GetFloat("highscore") % 60);
        float milliseconds = ((PlayerPrefs.GetFloat("highscore") % 60) - seconds) * 100;
        highscoreText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);


    }

}
