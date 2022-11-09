using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSound;
    public float bulletSpeed = 20f;
    public SpriteRenderer muzzleflash;
    public int muzzleFlashFramesActive;
    private int mfCurrentFrames;

    private float fireRate = .25f;
    private float fireTimer = 0f;

    private Player p;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = 0f;
        p = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input system is kinda weird. This will detect mouse left clicks
        if (Input.GetButton("Fire1") && fireTimer >= fireRate && !p.isDead)
        {
            //Fire Bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            shootSound.Play();

            //muzzleflash animation
            muzzleflash.enabled = true;
            mfCurrentFrames = muzzleFlashFramesActive;


            fireTimer = 0f;
        }
        else
        {
            if (muzzleflash.enabled && mfCurrentFrames <= 0)
            {
                muzzleflash.enabled = false;
            } 
            else
            {
                mfCurrentFrames--;
            }

            fireTimer += Time.deltaTime;
        }
    }
}
