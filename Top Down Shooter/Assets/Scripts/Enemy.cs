using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioSource deathSound;
    public BoxCollider2D hitbox;


    [Header("Enemy Stats")]
    public int maxHp = 3;
    private int currentHp;
    [HideInInspector]
    public bool isDead = false;

    [Header("Enemy visuals")]
    private SpriteRenderer sr;
    public Sprite damagedSprite;
    public Animator anim;


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
        }
    }

    //Deals damage to enemy. Returns true if enemy dies.
    private bool DealDamage()
    {
        currentHp--;

        if (currentHp <= 0)
        {
            //deathSound.Play();    eventually
            Die();
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

    private void Die()
    {
        hitSound.Play();
        hitbox.enabled = false;
        anim.SetBool("isDead", true);
        Destroy(gameObject, .75f); //wait to allow sound to play

    }
}
