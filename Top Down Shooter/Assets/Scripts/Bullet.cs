using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;    //To be used later for animation

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        //gameObject effect = Instatiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
