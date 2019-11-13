using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyController : MonoBehaviour
{
    public float bossHP = 100;
    private float positionChange = 5f;
    private float burstAmount = 4;

    private Vector3 ballSpawnPosition;
    private Vector2 shootingDirection;

    public GameObject boss;
    public GameObject bugPrefab;
    public GameObject bossLightballPrefab;

    BossEventManager manager;

    private void Start()
    {
        shootingDirection = Vector2.up;
        StartBossFight();

        manager = GetComponent<BossEventManager>();
    }


    // boss shoots burst of 4 lightballs, starts shooting after 1s from spawning, shoots bursts every 1s
    private void StartBossFight()
    {
        InvokeRepeating("ShootBurst", 1, 1);
    }


    private void ShootBurst()
    {
        StartCoroutine("BossShoots");
    }


    // takes dmg from player ammo, ignores collisions with its own ammo
    void OnCollisionEnter2D(Collision2D collided)
    {
        if (collided.gameObject.tag == "Ammo")
        {
            Debug.Log("Boss was hit");
            bossHP = bossHP - 10;
            if (bossHP <= 0)
            {
                Destroy(gameObject);
                BossEventManager.OnBossDying();
                Instantiate(bugPrefab, boss.transform.position, boss.transform.rotation);
            }
        }

        if (collided.gameObject.tag == "BossAmmo")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collided.gameObject.GetComponent<Collider2D>());
            return;
        }
    }


    private IEnumerator BossShoots()
    {
        for (int i = 0; i < burstAmount; i++)
        {
            shootingDirection = GetShootingDirection();
            Instantiate(bossLightballPrefab, (boss.transform.position + ballSpawnPosition), boss.transform.rotation).GetComponent<BossLightball>().Shoot(shootingDirection);
        }
        yield return null;
    }


    // boss shoots in four directions: up, right, down and left, ammoballs spawn in different positions depending on shootingDirection
    private Vector2 GetShootingDirection()
    {
        if (shootingDirection == Vector2.up)
        {
            shootingDirection = Vector2.right;
            ballSpawnPosition = new Vector3(positionChange, 0, 0);
        }
        else if (shootingDirection == Vector2.right)
        {
            shootingDirection = Vector2.down;
            ballSpawnPosition = new Vector3(0, -positionChange, 0);
        }
        else if (shootingDirection == Vector2.down)
        {
            shootingDirection = Vector2.left;
            ballSpawnPosition = new Vector3(-positionChange, 0, 0);
        }
        else if (shootingDirection == Vector2.left)
        {
            shootingDirection = Vector2.up;
            ballSpawnPosition = new Vector3(0, positionChange, 0);
        }

        return shootingDirection;
    }
}