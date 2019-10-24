using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownRotateMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //Vector2 moveDir = new Vector2(x, y);
        //GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = y * transform.up + x * transform.right;
        moveDir.Normalize();
        transform.up = moveDir;
        moveDir = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
    }
}
