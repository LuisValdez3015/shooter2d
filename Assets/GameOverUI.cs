using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Score score;
    public Text ScoreLabel;
    public Text HIghScoreLabel;
    private void OnEnable()
    {
        int currentScore = score.GetScore();
        ScoreLabel.text = "Score: " + currentScore;

        int Highscore = PlayerPrefs.GetInt("highscore", 0);
        HIghScoreLabel.text = "HIghscore: " + Highscore;
        if(currentScore>Highscore)
            PlayerPrefs.SetInt("highscore", currentScore);
        
        
    }
    public void RestartGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
