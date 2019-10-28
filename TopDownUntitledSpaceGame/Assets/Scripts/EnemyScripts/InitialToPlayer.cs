using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialToPlayer : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 2.0f;
    Vector3 startPosition;

    public float rotationSpeed = 2.0f;
    void Start()
    {
        startPosition = transform.position;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        Chase();
    }
    // This is not nonsense code right?
    void Update()
    {
        //Makes sprite face direction object is moving
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
