﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour
{
    Transform player;
    public GameObject prefab;
    public float bulletSpeed;
    public float bulletlifetime = 1.0f;
    public float shootDelay = 1.0f;
    public float fireRange = 1.0f;
    float timer = 0;
    public Vector2 distance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        Vector2 playerPosition = player.transform.position;
        distance = player.transform.position - transform.position;
        timer += Time.deltaTime;

        if (distance.magnitude < fireRange && timer > shootDelay)
        {
            timer = 0;
            GameObject bullet = Instantiate(prefab, transform.position, transform.rotation);
            //Debug.Log(playerPosition);
            Vector2 shootDir = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            bullet.transform.up = shootDir;
            Destroy(bullet, bulletlifetime);
        }
    }

}
