using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float runningTime;

    // Update is called once per frame
    void Update()
    {
        runningTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(runningTime / 60);
        int seconds = Mathf.FloorToInt(runningTime % 60);
        float milliseconds = ((runningTime % 60) - seconds) * 100;
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
