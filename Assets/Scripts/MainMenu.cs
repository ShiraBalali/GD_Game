using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        ScoreKeeper.currentTimer = 0;
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayTutorial()
    {
        ScoreKeeper.currentTimer = 0;
        SceneManager.LoadSceneAsync("Game Guide");
    }
}
