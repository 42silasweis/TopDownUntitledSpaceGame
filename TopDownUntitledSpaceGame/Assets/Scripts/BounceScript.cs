using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    Vector2 moveDir;
    Rigidbody2D rb;
    public float moveSpeed = 1.0f;
    public float rotationSpeed = 3.0f;
    List<Vector2> oldSpeeds;
    Vector2 switchVel;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();
        switchVel = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

        //switchVel = new Vector2(3, 5) * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = switchVel * moveSpeed * 1;

        //Makes enemy face direction it is moving
        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
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
        switchVel = dir * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = switchVel;
    }
}
