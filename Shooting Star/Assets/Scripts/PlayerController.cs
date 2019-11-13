using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;

    private float dashSpeed = 8000f;
    private float speed = 10f;

    private float movementX;
    private float movementY;
    private float move;

    private bool facingRight;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        facingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        // in order to make player move, we need x and y axis, and public variable speed, which we use to form the velocity vector for the player
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
        move = movementX * speed;
        player.velocity = new Vector2(move, movementY * speed);

        if (move < 0 && facingRight) // player is going left but facing right
        {
            Flip();
        }
        if (move > 0 && !facingRight) // player is going right but facing left
        {
            Flip();
        }
        // player can dash forward from E
        if (Input.GetKeyDown(KeyCode.E))
        {
            Dash();
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    private void Dash()
    {
        if (facingRight)
            player.AddForce(Vector2.right * dashSpeed);

        else
            player.AddForce(Vector2.left * dashSpeed);
    }


    // player only dies from boss ammo
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BossAmmo") Destroy(gameObject);
    }
}