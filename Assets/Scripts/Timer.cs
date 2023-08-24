using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static float currentTimer = 0;
}

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        ScoreKeeper.currentTimer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(ScoreKeeper.currentTimer / 60);
        int seconds = Mathf.FloorToInt(ScoreKeeper.currentTimer % 60);
        float milliseconds = ((ScoreKeeper.currentTimer % 60) - seconds) * 100;
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
