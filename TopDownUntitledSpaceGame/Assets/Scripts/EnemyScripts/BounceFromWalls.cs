﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceFromWalls : MonoBehaviour
{
    // Float a rigidbody object a set distance above a surface.

    public float floatHeight;     // Desired floating height.
    public float liftForce;       // Force to apply when lifting the rigidbody.
    public float damping;         // Force reduction proportional to speed (reduces bouncing).

    Rigidbody2D rb2D;

    public Transform player;
    public float chaseSpeed = 2.0f;
    Vector3 startPosition;

    public float rotationSpeed = 3.0f;


    void Start()
    {
        startPosition = transform.position;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        Chase();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);

        // If it hits something...
        if (hit.normal.y != 0)
        {
        rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * hit.normal.y);
        }
        if (hit.normal.x != 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * hit.normal.x);
        }
        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
        }
    }
    void Chase() // Chase function
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
}
