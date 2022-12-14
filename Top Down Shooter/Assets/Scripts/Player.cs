using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioSource deathSound;
    public AudioSource damagedSound;
    public Rigidbody2D rb;
    public SpriteRenderer sr;


    public int maxHp = 5;
    private int currentHp;
    public bool isDead = false;     //public so movement can be turned off in PlayerMovement script

    //IFrame Stuff
    public float InvulSeconds = 1.0f; //time of invulnrability.
    float timeInvul = 0f;
    bool invul = false;
    public BoxCollider2D hitbox;
    bool srOff = false;

    //UI
    [Header("UI")]
    public HealthBar hpBar;
    public GameObject gameOverScreen;
<<<<<<< Updated upstream
    public Text wavesSurvivedText;
=======
    public GameObject shopScreen;
    public Text wavesSurvivedText;
    public Text totalScore;
>>>>>>> Stashed changes

    [Header("Misc")]
    public WaveManager waveManager;
    public AudioSource bgMusic;
    public AudioSource deathMusic;
<<<<<<< Updated upstream
=======
    public ScoreManager scoreManager;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        hpBar.SetMaxHealth(maxHp);
        gameOverScreen.SetActive(false);
<<<<<<< Updated upstream
        deathMusic.Stop();
=======
        shopScreen.SetActive(false);
        deathMusic.Stop();
        //currentWeapon = gameOverScreen.GetComponent<Weapon>();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        if (invul && timeInvul < InvulSeconds)
        {
            timeInvul += Time.deltaTime;

            //flash Sprite
            if (srOff)
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
        else if (invul && timeInvul >= InvulSeconds && !isDead)
        {
            //Turn off IFrames
            Debug.Log("ENDING IFRAMES!");
            invul = false;
            timeInvul = 0f;

            //Make sure sprite is rendered
            if (srOff)
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
                StartCoroutine(ToEndScreen());
            }
        }
    }

    //Deals damage to player. Returns true if player dies.
    private bool DealDamage()
    {
        if (!invul)
        {
            currentHp--;
            Debug.Log("Player Hit! HP = " + currentHp);
            hpBar.SetHealth(currentHp);

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

    IEnumerator ToEndScreen()
    {
        yield return new WaitForSeconds(2);

        gameOverScreen.SetActive(true);
<<<<<<< Updated upstream
        int wavesSurvived = waveManager.wave - 1;

        //Grammer corner case... always annoys me
        if(wavesSurvived == 1)
=======

        int wavesSurvived = waveManager.wave - 1;
        scoreManager = ScoreManager.FindObjectOfType<ScoreManager>();
        //Grammer corner case... always annoys me
        if (wavesSurvived == 1)
>>>>>>> Stashed changes
            wavesSurvivedText.text = ("You Survived 1 Wave.");
        else
            wavesSurvivedText.text = ("You Survived " + wavesSurvived + " Waves.");

<<<<<<< Updated upstream
=======
        //totalScore.text = ("Your total score was " + scoreManager.totalScore);Too lazy for right now

>>>>>>> Stashed changes
        bgMusic.Stop();
        deathMusic.Play();
    }
}
