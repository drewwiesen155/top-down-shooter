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
<<<<<<< Updated upstream
=======
    public int killReward;
>>>>>>> Stashed changes
    [HideInInspector]
    public bool isDead = false;

    [Header("Enemy visuals")]
    //private SpriteRenderer sr;
    //public Sprite damagedSprite;  Now done in animation
    public bool hasDmgedSprite;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        //sr = gameObject.GetComponent<SpriteRenderer>();
<<<<<<< Updated upstream
=======
        scoreManager = ScoreManager.FindObjectOfType<ScoreManager>();
        player = Player.FindObjectOfType<Player>();
>>>>>>> Stashed changes
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

            if (currentHp <= (maxHp / 2) && hasDmgedSprite)
            {
                //Yes the damaged sprite needs some serious work...
                anim.SetBool("isDmged", true);
            }

            hitSound.Play();
            return false;
        }
    }

    private void Die()
    {
<<<<<<< Updated upstream
=======
        scoreManager.AddScore(killReward, player.currentWeapon.scoreMultiplier);//score stuff
>>>>>>> Stashed changes
        hitSound.Play();
        hitbox.enabled = false;
        anim.SetBool("isDead", true);
        Destroy(gameObject, .75f); //wait to allow sound to play

    }
}
