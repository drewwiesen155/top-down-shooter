using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float dirX, dirY = 0;
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(dirX * moveSpeed * Time.deltaTime, dirY * moveSpeed * Time.deltaTime);

        transform.position = new Vector2(transform.position.x, transform.position.y) + movement;

    }
}
