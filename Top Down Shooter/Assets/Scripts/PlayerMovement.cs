using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float dirX, dirY = 0;
    public float moveSpeed = 5f;
    
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(dirX * moveSpeed * Time.fixedDeltaTime, dirY * moveSpeed * Time.fixedDeltaTime);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y) + movement;

        Vector2 lookDir = mousePos - rb.position;
        //Atan takes args as (y, x)
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //needs offset for some reason
        rb.rotation = angle;
    }
}
