using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBullet2 : MonoBehaviour
{
    float bulletspeed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        bulletspeed = Player.GetComponent<PlayShoot>().bulletSpeed;
        GetComponent<Rigidbody2D>().AddForce(transform.up * bulletspeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
