using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    Vector2 moveDir;
    Rigidbody2D rb;
    public float moveSpeed = 0.6f;
    public float rotationSpeed = 3.0f;
    List<Vector2> oldSpeeds;
    Vector2 switchVel;
    Transform player;
    public GameObject Particle;

    public float spawnRangeX = 1.5f;
    public float spawnRangeY = 1.5f;
    float spawnDistanceX;
    float spawnDistanceY;
    float spawnDistanceX2;
    float spawnDistanceY2;
    Vector3 RandomPosition1;

    public float delay = 0.2f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawnDistanceX = player.transform.position.x;
        spawnDistanceY = player.transform.position.y;
        spawnDistanceX2 = player.transform.position.x - spawnRangeX;
        spawnDistanceY2 = player.transform.position.y - spawnRangeY;

        RandomPosition1 = new Vector3(Random.Range(spawnDistanceX2, spawnDistanceX), Random.Range(spawnDistanceY2, spawnDistanceY));
        //transform.up = RandomPosition1;
        rb = GetComponent<Rigidbody2D>();
        switchVel = new Vector2(RandomPosition1.x - transform.position.x, RandomPosition1.y - transform.position.y);
        switchVel.Normalize();
        GetComponent<Rigidbody2D>().velocity = switchVel * moveSpeed;
        //switchVel = new Vector2(3, 5) * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = switchVel * moveSpeed;

        //Makes enemy face direction it is moving
        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
        }

        //This is the particle trail that follows the Enemy, set by GameObject
        timer += Time.deltaTime;
        if (timer > delay)
        {
            timer = 0;
            Instantiate(Particle, transform.position, transform.rotation);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Vector3 normal = collision.GetContact(0).normal;
        Vector3 dir = switchVel;
        
        if((normal.x < 0 && switchVel.x > 0 || normal.x > 0 && switchVel.x < 0) && Mathf.Abs(normal.x)>0.1f)
        {
            dir.x *= -1;
        }
        if(normal.y < 0 && switchVel.y > 0 || normal.y > 0 && switchVel.y < 0 && Mathf.Abs(normal.y) > 0.1f)
        {
            dir.y *= -1;
        }
        switchVel = dir;
        GetComponent<Rigidbody2D>().velocity = switchVel * moveSpeed;
    }
}
