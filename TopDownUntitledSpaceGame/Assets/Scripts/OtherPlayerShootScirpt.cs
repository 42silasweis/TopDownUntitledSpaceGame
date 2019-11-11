using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayerShootScirpt : MonoBehaviour
{
    public GameObject prefab1;
    GameObject theBullet;
    public float bulletSpeed = 8.0f;
    public float bulletlifetime = 4.0f;
    public float shootDelay;
    float timer = 0;


    public float spawnRangeX = 1.5f;
    public float spawnRangeY = 1.5f;
    float spawnDistanceX;
    float spawnDistanceY;
    float spawnDistanceX2;
    float spawnDistanceY2;
    Vector3 RandomPosition1;
    //public int bullet3NeededPoints;
    int currentPoints;

    void Start()
    {
        theBullet = prefab1;
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > shootDelay)
        {
            timer = 0;
            GameObject bullet = Instantiate(theBullet, transform.position, transform.rotation);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            spawnDistanceX = mousePosition.x + spawnRangeX; // lines 51-55 are to randomize the bullets direction based on the offset
            spawnDistanceY = mousePosition.y + spawnRangeY;
            spawnDistanceX2 = mousePosition.x - spawnRangeX;
            spawnDistanceY2 = mousePosition.y - spawnRangeY;
            RandomPosition1 = new Vector3(Random.Range(spawnDistanceX2, spawnDistanceX), Random.Range(spawnDistanceY2, spawnDistanceY));

            Vector2 shootDir = new Vector2(RandomPosition1.x - transform.position.x, RandomPosition1.y - transform.position.y);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = (shootDir * bulletSpeed) + GetComponentInParent<Rigidbody2D>().velocity;
            bullet.transform.up = shootDir;
            Destroy(bullet, bulletlifetime);
        }
    }
}
