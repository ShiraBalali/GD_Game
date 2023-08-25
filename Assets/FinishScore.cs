using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    private void Awake()
    {
        int minutes = Mathf.FloorToInt(ScoreKeeper.currentTimer / 60);
        int seconds = Mathf.FloorToInt(ScoreKeeper.currentTimer % 60);
        float milliseconds = ((ScoreKeeper.currentTimer % 60) - seconds) * 100;
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

}
