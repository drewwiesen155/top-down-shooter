using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSound;
    public float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input system is kinda weird. This will detect mouse left clicks
        if (Input.GetButtonDown("Fire1"))
        {
            //Fire Bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            shootSound.Play();
        }
    }
}
