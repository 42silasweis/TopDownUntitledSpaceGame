using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AI : MonoBehaviour
{
    Transform player;
    public float chaseSpeed = 0.6f;
    public float chaseTriggerDistance = 50.0f;
    public float rotationSpeed = 3.0f;
    float startTimer;
    Vector3 startPosition;
    void Start()
    {
        startTimer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // This is not nonsense code right?
    void Update()
    {
        startTimer += Time.deltaTime;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if (chaseDirection.magnitude < chaseTriggerDistance && startTimer > 1)
        {
            Chase();
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
