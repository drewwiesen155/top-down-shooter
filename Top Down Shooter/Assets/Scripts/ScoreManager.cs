using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int totalScore;//overall score, never gets subtracted from
    public int currentScore;//current score, is the currency to shop with
    public int scoreMultiplier;

    public Text scoreBoard;


    // Start is called before the first frame update
    void Start()
    { 
        scoreBoard.text = ("Score: 0");
    }

    public void AddScore(int enemyCost, int multiplier)//this goes into enemy dying
    {
        currentScore += enemyCost * multiplier;
        totalScore += enemyCost * multiplier;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreBoard.text = ("Score: " + currentScore);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
