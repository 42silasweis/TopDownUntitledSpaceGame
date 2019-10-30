using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBullet2 : MonoBehaviour
{
    GameObject Player;
    float bulletspeed;
    Vector3 rb;

    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        bulletspeed = Player.GetComponentInChildren<PlayShoot>().bulletSpeed;
        //bulletspeed = Player.GetComponent<PlayShoot>().bulletSpeed; //This line is only used if the PlayShoot script is on the Player and not one of its children
        rb = Player.GetComponent<Rigidbody2D>().velocity;
        //GetComponent<Rigidbody2D>().AddForce(transform.up * bulletspeed + rb);
        GetComponent<Rigidbody2D>().velocity = (transform.up * bulletspeed) + rb;
    }

    void Update()
    {
        /*
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        bulletspeed = Player.GetComponentInChildren<PlayShoot>().bulletSpeed;
        //bulletspeed = Player.GetComponent<PlayShoot>().bulletSpeed;
        rb = Player.GetComponent<Rigidbody2D>().velocity;
        //GetComponent<Rigidbody2D>().AddForce(transform.up * bulletspeed + rb);
        GetComponent<Rigidbody2D>().velocity = (transform.up * bulletspeed) + rb;
        */
    }
}
