using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;    //To be used later for animation

    private float xMin = -25;
    private float xMax = 25;
    private float yMin = -25;
    private float yMax = 25;

    void Start()
    {
        InvokeRepeating("CheckLocation", 1f, 1f);  //1s delay, repeat every 1s
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Player")
        //gameObject effect = Instatiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);
    }

    void CheckLocation()
    {
        if (transform.position.x >= xMax || transform.position.x <= xMin)
            Destroy(gameObject);

        if (transform.position.y >= yMax || transform.position.y <= yMin)
            Destroy(gameObject);
    }
}
