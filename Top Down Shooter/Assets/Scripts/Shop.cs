using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ScoreManager scoreManager;

    //takes score, changes weapon, then goes into update shop
    //this is called by the button in the shop
    //pass in the weapon being bought - which also contains the cost of it
    //how do I change currentScore?
    //pass in scoreManager?
    public void Buy(Weapon weapon)
    {
        scoreManager = ScoreManager.FindObjectOfType<ScoreManager>();
        scoreManager.currentScore -= weapon.scoreCost;
        scoreManager.UpdateScore();


    }

    public void UpdateShop()
    {

    }

}
