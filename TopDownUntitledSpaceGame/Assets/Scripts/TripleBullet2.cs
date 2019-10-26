using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBullet2 : MonoBehaviour
{
    float bulletspeed;
    Vector3 rb;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        bulletspeed = Player.GetComponent<PlayShoot>().bulletSpeed;
        rb = Player.GetComponent<Rigidbody2D>().velocity;
        //GetComponent<Rigidbody2D>().AddForce(transform.up * bulletspeed + rb);
        GetComponent<Rigidbody2D>().velocity = (transform.up * bulletspeed) + rb;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
