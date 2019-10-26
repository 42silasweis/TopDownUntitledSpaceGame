using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayShoot : MonoBehaviour
{
    public GameObject prefab;
    public float bulletSpeed = 10.0f;
    public float bulletlifetime = 1.0f;
    public float shootDelay = 1.0f;
    float timer = 0;
    float playerVelocity;
    void Start()
    {
        //GameObject Player = GameObject.FindGameObjectWithTag("Player");
        //playerVelocity = Player.GetComponent<PlayerMovement>().moveDir;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > shootDelay)
        {
            timer = 0;
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //Debug.Log(mousePosition);
            Vector2 shootDir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            shootDir.Normalize();
            bullet.GetComponentInParent<Rigidbody2D>().velocity = shootDir * bulletSpeed + GetComponentInParent<Rigidbody2D>().velocity;
            //bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            bullet.transform.up = shootDir;
            Destroy(bullet, bulletlifetime);


        }
    }

}
