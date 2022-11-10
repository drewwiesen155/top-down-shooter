using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float dirX, dirY = 0;
    public float moveSpeed = 5f;
    private float deltaX = 0;
    private float deltaY = 0;
    private float maxDiagonal = 3.536f; //Max diagonal distance based on moveSpeed (Pythag/2)

    public Camera cam;
    public Rigidbody2D rb;

    Vector2 mousePos;
    Vector2 movement;

    private float xMin = -15;
    private float xMax = 15;
    private float yMin = -8;
    private float yMax = 8;

    private Player p;

    void Start()
    {
        p = gameObject.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!p.isDead)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");

            deltaX = dirX * moveSpeed;
            deltaY = dirY * moveSpeed;


            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

    }

    void FixedUpdate()
    {
        if (!p.isDead)
        {
            //Set max Diagonal Speed. Avoid OG Doom speedrun bug
            if (dirX > 0 && dirY > 0)
            {
                deltaX = maxDiagonal;
                dirY = maxDiagonal;
            }
            else if (dirX > 0 && dirY < 0)
            {
                deltaX = maxDiagonal;
                dirY = -1 * maxDiagonal;
            }
            else if (dirX < 0 && dirY > 0)
            {
                deltaX = -1 * maxDiagonal;
                dirY = maxDiagonal;
            }
            else if (dirX < 0 && dirY < 0)
            {
                deltaX = -1 * maxDiagonal;
                dirY = -1 * maxDiagonal;
            }

            movement = new Vector2(deltaX * Time.fixedDeltaTime, deltaY * Time.fixedDeltaTime);

            transform.position = new Vector2(Mathf.Clamp(transform.position.x + movement.x, xMin, xMax), Mathf.Clamp(transform.position.y + movement.y, yMin, yMax));

            Vector2 lookDir = mousePos - rb.position;
            //Atan takes args as (y, x)
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //needs offset for some reason
            rb.rotation = angle;

            cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10); //-10 is the default value for 2D camera
        }
    }
}
