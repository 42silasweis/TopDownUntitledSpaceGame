using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public float paceSpeed = 1.5f;
    public float paceDistance = 3.0f;
    public float farFromHome = 10.0f;
    public Vector2 paceDirection;
    Vector3 startPosition;
    bool home = true;

    public float wanderRange;

    public float paceFrequency = 4.0f;
    public float paceTimer;
    public float rotationSpeed = 2.0f;

    public GameObject enemy;
    public float spawnTime = 10;
    public float spawnDelay = 0.6f;
    float time;
    float time2;
    void Start()
    {
        paceTimer = 0;
        startPosition = transform.position;
        Pace();
    }
    // This is not nonsense code right?
    void Update()
    {
        paceTimer += Time.deltaTime;
        Vector3 tooFar = transform.position - startPosition;

        time += Time.deltaTime;
        time2 += Time.deltaTime;


        if (time < 90 && time2 > spawnDelay)
        {
            time2 = 0;
            Instantiate(enemy, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);

        }


        //The Spawners random movement happens in the code below
        if (!home)
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

    }

    void GoHome() // Go back to home function
    {
        Vector2 homeDirection = new Vector2(startPosition.x - transform.position.x, startPosition.y - transform.position.y);
        if (homeDirection.magnitude < 0.1f)
        {
            transform.position = startPosition;
            home = true;
        }
        else
        {
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
