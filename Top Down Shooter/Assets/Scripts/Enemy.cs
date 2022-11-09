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
    public int killReward;
    [HideInInspector]
    public bool isDead = false;

    [Header("Enemy visuals")]
    private SpriteRenderer sr;
    public Sprite damagedSprite;
    public Animator anim;

    public ScoreManager scoreManager;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        sr = gameObject.GetComponent<SpriteRenderer>();
        scoreManager = ScoreManager.FindObjectOfType<ScoreManager>();
        player = Player.FindObjectOfType<Player>();
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
        currentHp -= player.currentWeapon.weaponDamage;

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
        scoreManager.AddScore(killReward, player.currentWeapon.scoreMultiplier);//score stuff

        hitSound.Play();
        hitbox.enabled = false;
        if(anim != null)
        {
            anim.SetBool("isDead", true);
            Destroy(gameObject, .75f);
        }
        else
        {
            
            Destroy(gameObject, .75f);
        }
        
        //Destroy(gameObject, .75f); //wait to allow sound to play

    }
}
