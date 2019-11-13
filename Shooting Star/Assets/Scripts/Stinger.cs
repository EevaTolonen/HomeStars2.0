using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stinger : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject lightBallPrefab;
    private GameObject lightBallContainer;

    private GameObject player;
    private Vector2 shootingDirection;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        if (player.transform.localEulerAngles.y >= 180f) shootingDirection = Vector2.right;
        else shootingDirection = Vector2.left;
        
        Instantiate(lightBallPrefab, firingPoint.position, firingPoint.rotation).GetComponent<LightBall>().Shoot(shootingDirection);
    }
}