using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource deathSound;
    public AudioSource damagedSound;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public int maxHp = 5;
    private int currentHp;
    bool isDead = false;

    //IFrame Stuff
    public float InvulSeconds = 1.0f; //time of invulnrability.
    float timeInvul = 0f;
    bool invul = false;
    public BoxCollider2D hitbox;
    bool srOff = false;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(invul && timeInvul <InvulSeconds)
        {
            timeInvul += Time.deltaTime;

            //flash Sprite
            if(srOff)
            {
                sr.enabled = true;
                srOff = false;
            }
            else
            {
                sr.enabled = false;
                srOff = true;
            }
        }
        else if(invul && timeInvul >= InvulSeconds && !isDead)
        {
            //Turn off IFrames
            Debug.Log("ENDING IFRAMES!");
            invul = false;
            timeInvul = 0f;

            //Make sure sprite is rendered
            if(srOff)
            {
                sr.enabled = true;
                srOff = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isDead = DealDamage();
            if (isDead)
            {
                //Destroy(gameObject, .75f);
                rb.bodyType = RigidbodyType2D.Static;   //Eliminates movement Doesnt work rn
                hitbox.enabled = false;
            }
        }
    }

    //Deals damage to player. Returns true if player dies.
    private bool DealDamage()
    {
        if(!invul)
        {
            currentHp--;
            Debug.Log("Player Hit! HP = " + currentHp);

            if (currentHp <= 0)
            {
                if (!isDead)
                {
                    deathSound.Play();
                }

                return true;
            }
            else
            {
                damagedSound.Play();

                //Start I frames
                Debug.Log("STARTING IFRAMES!");
                invul = true;
                timeInvul = 0;

                return false;
            }
        }
        else
        {
            Debug.Log("No Damamge! Payer Invulnrable!");
            return false;
        }

        
    }
}
