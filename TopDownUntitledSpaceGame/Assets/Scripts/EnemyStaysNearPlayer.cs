using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaysNearPlayer : MonoBehaviour
{
    Transform player;
    public float chaseSpeed = 0.6f;
    public float stayDistance = 5.0f;
    public float rotationSpeed = 3.0f;
    float afterSpawnDelay = 0.8f;
    float startTimer;
    Vector3 startPosition;
    bool spawnedIn = false;

    bool canChase;
    Vector3 bulletDist;
    GameObject target;
    public float speed = 3.0f;
    public float tooCloseToBullet = 1.0f;
    public float dist = 3;
    float initialDist;
    float timer;
    void Start()
    {
        initialDist = dist;
        startTimer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // This is not nonsense code right?
    void Update()
    {
        startTimer += Time.deltaTime;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if (chaseDirection.magnitude >= stayDistance)
        {
            Chase();
            
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
        }
        //AvoidingBullets start here
        timer += Time.deltaTime;
        if (target == null)
        {
            FindTarget();
        }

        if (dist < tooCloseToBullet)
        {
            canChase = false;
            transform.up = Vector3.Lerp(transform.up, target.transform.position - transform.position, 0.2f * timer);//0.053f);
            //float speed = GetComponent<Rigidbody2D>().velocity.magnitude;
            GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
        }
        if (chaseDirection.magnitude > 0.5)
        {
            target = null;
            canChase = true;
        }
    }
    void FindTarget() //Makes the bullets a target it can track
    {
        //dist = 3;
        dist = initialDist;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < dist)
            {
                target = enemies[i];
                //bulletDist = (transform.position - enemies[i].transform.position);
                dist = Vector3.Distance(transform.position, enemies[i].transform.position);
            }
        }
    }
    void Chase() // Chase function
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
}
