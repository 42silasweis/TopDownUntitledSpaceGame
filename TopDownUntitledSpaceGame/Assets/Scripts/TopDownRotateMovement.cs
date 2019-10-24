using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownRotateMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //Vector2 moveDir = new Vector2(x, y);
        //GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;

        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //mousePosition.z = transform.position.z;
        //transform.up = mousePosition - transform.position;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 moveDir = y * transform.up + x * transform.right;
        moveDir.Normalize();
        GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
    }
}
