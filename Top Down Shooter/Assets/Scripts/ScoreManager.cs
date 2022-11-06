using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int totalScore;
    public int currentScore;
    public int scoreMultiplier;

    public Text scoreBoard;
    //public Score score;


    // Start is called before the first frame update
    void Start()
    {
       // score = gameObject.AddComponent<Score>();

                
        scoreBoard.text = ("Score: 0");

    }

    public void AddScore(int enemyCost, int multiplier)//this goes into enemy dying
    {
        currentScore += enemyCost * multiplier;
        totalScore += currentScore;
        scoreBoard.text = ("Score: " + currentScore);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
