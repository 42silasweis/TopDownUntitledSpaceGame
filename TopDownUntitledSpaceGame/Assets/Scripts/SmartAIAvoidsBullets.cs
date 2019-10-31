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
    Vector3 startPosition;
    bool spawnedIn = false;

    GameObject target;
    public bool instant = false;
    public float speed = 3.0f;
    public float dist = 3;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        FindTarget();
        GetComponent<PolygonCollider2D>().enabled = false;
        startTimer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if (chaseDirection.magnitude < chaseTriggerDistance && startTimer > afterSpawnDelay)
        {
            Chase();
        }

        if (startTimer > afterSpawnDelay && spawnedIn == false)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            spawnedIn = true;
        }

        //AvoidingBullets start here
        timer += Time.deltaTime;
        if (target == null)
        {
            FindTarget();
        }
        if (dist < 3)
        {
            transform.up = Vector3.Lerp(transform.up, target.transform.position - transform.position, 0.2f * timer);//0.053f);
            //float speed = GetComponent<Rigidbody2D>().velocity.magnitude;
            GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
        }


        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
        }
    }
    void FindTarget()
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
        if (dist > 3)
        {
            target = null;
        }
    }
    void Chase() // Chase function
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
}
