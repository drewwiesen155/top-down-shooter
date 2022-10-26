using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input system is kinda weird. Getting errors when trying to just use space so used axis with space named Jump
        if (Input.GetButtonDown("Jump"))
        {
            //Fire Bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, bulletSpeed));
        }
    }
}
