using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static float currentTimer = 0;

    public static int colorTicks = 0;
    public static Color timeColor = Color.red;

    public static void Penalty()
    {
        if (ScoreKeeper.currentTimer > 0)
        {
            ScoreKeeper.currentTimer += 10f;
            ScoreKeeper.colorTicks = 500;

        }
    }
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

        if (ScoreKeeper.colorTicks > 0)
        {
            ScoreKeeper.colorTicks--;
            timerText.color = ScoreKeeper.timeColor;
        }
        else
        {
            timerText.color = Color.white;
        }

    }
}
