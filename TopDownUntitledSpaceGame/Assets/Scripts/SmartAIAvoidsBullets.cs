using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartAIAvoidsBullets : MonoBehaviour
{
    Transform player;
    public float chaseSpeed = 0.6f;
    public float chaseTriggerDistance = 50.0f;
    public float rotationSpeed = 3.0f;
    float afterSpawnDelay = 0.8f;
    float startTimer;
    float bulletDist;
    bool canChase;

    GameObject target;
    public float speed = 3.0f;
    public float tooCloseToBullet = 1.0f;
    public float dist = 100;
    float timer;

    void Start()
    {
        canChase = true;
        FindTarget();
        startTimer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //Start chasing after  the set spawn delay and then chase the player
        startTimer += Time.deltaTime;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if (chaseDirection.magnitude < chaseTriggerDistance && startTimer > afterSpawnDelay && canChase == true)
        {
            Chase();
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
            GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
        }
        if (dist > tooCloseToBullet)
        {
            target = null;
            canChase = true;
        }


        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity; //Rotates the sprite to face the direction the enemy is moving
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
        }
    }
    void FindTarget() //Makes the bullets a target it can track
    {       
        //dist = 10000;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("PBulletParent"); 
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < dist)
            {
                target = enemies[i];
                dist = Vector3.Distance(transform.position, enemies[i].transform.position);
            }
        }
    }

    void Chase() // Chase the player
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
}
