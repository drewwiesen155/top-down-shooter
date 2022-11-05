using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1f;

    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        //flip sprite if facing the wrong way
        Vector2 dir = player.position - transform.position;

        //sprites face left. Left should be negative X so positive X needs flipped sprite;
        if (dir.x > 0 && facingLeft)
            Flip();
        else if (dir.x < 0 && !facingLeft)
            Flip();
    }

    //Flips the sprite 180 degrees
    void Flip()
    {
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x *= -1;
        gameObject.transform.localScale = newScale;
        facingLeft = !facingLeft;
    }
}
