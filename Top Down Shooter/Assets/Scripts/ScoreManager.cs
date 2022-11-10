using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public float totalScore;//overall score, never gets subtracted from
    public float currentScore;//current score, is the currency to shop with



    public float scoreMultiplier;

    public Text scoreBoard;


    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.text = ("Score: 0");
    }

    public void AddScore(int enemyReward, float multiplier)//this goes into enemy dying
    {
        currentScore += enemyReward * multiplier;
        totalScore += enemyReward * multiplier;
        currentScore = Mathf.Abs(currentScore);
        totalScore = Mathf.Abs(totalScore);

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
