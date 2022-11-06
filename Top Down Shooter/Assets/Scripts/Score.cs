using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int totalScore;
    public int currentScore;
    public int scoreMultiplier;

    public void AddScore(int enemyCost, int multiplier)//this goes into enemy dying
    {
        currentScore += enemyCost * multiplier;
        totalScore += currentScore;
        Debug.Log(currentScore);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
