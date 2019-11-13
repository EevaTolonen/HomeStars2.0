using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtCollision : MonoBehaviour
{
    public GameObject dirt;

    void OnCollisionEnter2D(Collision2D whoHit)
    {
        if (whoHit.gameObject.tag == "Ammo" )
        {
            Destroy(gameObject);
        }
    }
}
