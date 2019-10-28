using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 2.0f;
    public float paceSpeed = 1.5f;
    public float paceDistance = 3.0f;
    public float chaseTriggerDistance = 5.0f;
    public float farFromHome = 10.0f;
    public Vector2 paceDirection;
    Vector3 startPosition;
    bool home = true;
    bool canChase = true;

    public float wanderRange;
    Transform targetLocation;
    public float paceFrequency = 4.0f;
    public float paceTimer;
    public float rotationSpeed = 2.0f;
    void Start()
    {
        paceTimer = 0;
        startPosition = transform.position;
    }
    // This is not nonsense code right?
    void Update()
    {
        paceTimer += Time.deltaTime;
        Vector3 tooFar = transform.position - startPosition;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if (chaseDirection.magnitude < chaseTriggerDistance && tooFar.magnitude < farFromHome && canChase == true)
        {
            Chase();
        }

        else if (!home)
        {
            GoHome();
        }

        else if (tooFar.magnitude > farFromHome)
        {
            GoHome();
        }

        else if (paceTimer > paceFrequency)
        {
            Pace();
        }

        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
        }
    }

void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Playershoot")
        {
            canChase = true;
        }
    }

    void Chase() // Chase function
    {
        home = false;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
    void GoHome() // Go back to home function
    {
        Vector2 homeDirection = new Vector2(startPosition.x - transform.position.x, startPosition.y - transform.position.y);
        if(homeDirection.magnitude < 0.1f)
        {
            transform.position = startPosition;
            home = true;
            canChase = true;
        }
        else
        {
            canChase = false;
            homeDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = homeDirection * paceSpeed;
        }
    }
    void Pace() // Pacing when at home
    {
        paceTimer = 0;
        paceDirection = new Vector2(Random.Range(-paceDistance, paceDistance), Random.Range(-paceDistance, paceDistance));
        paceDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = paceDirection * paceSpeed;
    }
}

