using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBall : MonoBehaviour
{
    public Rigidbody2D ammo;
    private float lightBallSpeed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Rigidbody2D>();
    }


    public void Shoot(Vector2 direction)
    {
        ammo.AddForce(direction * lightBallSpeed);
    }


    // ammo is destroyed if it hits something, minus player & other ammos from player
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ammo")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
        Destroy(gameObject);
    }
}