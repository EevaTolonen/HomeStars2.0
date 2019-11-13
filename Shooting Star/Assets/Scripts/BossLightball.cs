using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLightball : MonoBehaviour
{
    public Rigidbody2D lightBall;
    private float lightBallSpeed = 500f;
    // Start is called before the first frame update
    void Start()
    {
        lightBall = GetComponent<Rigidbody2D>();
        //lightBall.AddForce(Vector2.up * lightBallSpeed);
    }


    public void Shoot(Vector2 shootingDirection)
    {

        lightBall.AddForce(shootingDirection * 500);
    }


    void OnCollisionEnter2D(Collision2D whoHit)
    {
        if (whoHit.gameObject.tag == "BossAmmo" || whoHit.gameObject.tag == "Boss")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), whoHit.gameObject.GetComponent<Collider2D>());
            return;
        }
        else
            Destroy(gameObject);
    }
}
