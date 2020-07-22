using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    private void Start()
    {
        scoreText.text = "Score" + scoreValue;
    }
    private int scoreValue;
    public Text scoreText;

    public void AddPoints(int points)
    {
        scoreValue += points;
        scoreText.text="Score"+scoreValue;
    }
    public void ReducePoints(int points)
    {
        scoreValue -= points;
    }

    public int GetScore()
    {
        return scoreValue;
    }
}
