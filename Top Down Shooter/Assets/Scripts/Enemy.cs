using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioSource deathSound;


    [Header("Enemy Stats")]
    public int maxHp = 3;
    private int currentHp;
    bool isDead = false;

    [Header("Enemy visuals")]
    private SpriteRenderer sr;
    public Sprite damagedSprite;
    //public bool hasDamagedSprite;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Checking if enemy has been hit with a bullet
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            isDead = DealDamage();
            if (isDead)
            {
                Destroy(gameObject, .15f); //wait to allow sound to play
            }
        }
    }

    //Deals damage to enemy. Returns true if enemy dies.
    private bool DealDamage()
    {
        currentHp--;

        if (currentHp <= 0)
        {
            //deathSound.Play();    eventually
            hitSound.Play();
            return true;

           
        }
        else
        {

            if (currentHp <= (maxHp / 2) && damagedSprite != null)
            {
                //Yes the damaged sprite needs some serious work...
                sr.sprite = damagedSprite;
            }

            hitSound.Play();
            return false;
        }
    }
}
