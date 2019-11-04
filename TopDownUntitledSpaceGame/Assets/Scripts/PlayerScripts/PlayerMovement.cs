using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    Vector3 playerMove;
    public float delay = 0.2f;
    float timer = 0;
    public GameObject Particle;

    void Start()
    {

    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 moveDir = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;

        //This is the particle trail that follows the player, set by GameObject
        timer += Time.deltaTime;
        if (Input.GetButton("Horizontal") && timer > delay || Input.GetButton("Vertical") && timer > delay)
        {
            timer = 0;
            Instantiate(Particle, transform.position, transform.rotation);
        }


        //This function is to make the player sprite face the direction it is moving
        //I believe it requires the sprite to be a Child of the main Player/Object and rotated 90 degrees
        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
        }
        /*
                Vector3 moveDirection = gameObject.transform.position; 
        if (moveDirection != Vector3.zero) 
        {
             float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        Extra line that I don't think will ever be used
        Vector3 playerVelocity = GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
        */
    }
}

