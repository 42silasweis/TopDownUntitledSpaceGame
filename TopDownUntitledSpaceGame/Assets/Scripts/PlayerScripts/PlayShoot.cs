using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayShoot : MonoBehaviour
{
    GameObject player;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    GameObject theBullet;
    public float bulletSpeed = 10.0f;
    public float bulletlifetime = 1.0f;
    public float shootDelay;
    public float shootDelay1 = 1.0f;
    public float shootDelay2 = 1.0f;
    float timer = 0;
    public int bullet1NeededPoints;
    public int bullet2NeededPoints;
    //public int bullet3NeededPoints;
    int currentPoints;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        theBullet = prefab1;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        currentPoints = player.GetComponentInChildren<CoinCollect1>().Points;

        if (currentPoints > bullet1NeededPoints && currentPoints < bullet2NeededPoints)
        {
            theBullet = prefab2;
            shootDelay = shootDelay1;
        }
        if(currentPoints > bullet2NeededPoints)
        {
            theBullet = prefab3;
            shootDelay = shootDelay2;
        }

        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > shootDelay)
        {
            timer = 0;
            GameObject bullet = Instantiate(theBullet, transform.position, transform.rotation);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //Debug.Log(mousePosition);
            Vector2 shootDir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = (shootDir * bulletSpeed) + GetComponentInParent<Rigidbody2D>().velocity;
            //bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            bullet.transform.up = shootDir;
            //Debug.Log(shootDir);
            Destroy(bullet, bulletlifetime);
        }
    }

}
