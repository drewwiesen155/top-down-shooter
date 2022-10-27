using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource deathSound;
    public Rigidbody2D rb;

    public int maxHp = 5;
    private int currentHp;
    bool isDead = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isDead = DealDamage();
            if (isDead)
            {
                //Destroy(gameObject, .75f);
                rb.bodyType = RigidbodyType2D.Static;   //Eliminates movement
            }
        }
    }

    //Deals damage to player. Returns true if player dies.
    private bool DealDamage()
    {
        currentHp--;
        Debug.Log("Player Hit! HP = " + currentHp);

        if (currentHp <= 0)
        {
            deathSound.Play();
            return true;            
        }
        else
        {            
            //Start I frames
            return false;
        }
    }
}
