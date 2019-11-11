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
    bool tripleBulletActive = false;
    bool boostActive2 = false;
    bool boostActive3 = false;

    bool boostActive = false;
    public float bulletBoostTime = 30;
    public float bulletBoostLastingTime = 30;
    float timer2;
    float timer3;

    public float spawnRangeX = 0.2f;
    public float spawnRangeY = 0.2f;
    float spawnDistanceX;
    float spawnDistanceY;
    float spawnDistanceX2;
    float spawnDistanceY2;
    Vector3 RandomPosition1;
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
        timer2 += Time.deltaTime;
        timer3 += Time.deltaTime;
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
        if(currentPoints > bullet2NeededPoints && tripleBulletActive == false)
        {
            tripleBulletActive = true;
            timer2 = 0;
            timer3 = 0;
            theBullet = prefab3;
            shootDelay = shootDelay2;
        }

        if (currentPoints > bullet2NeededPoints && timer2 > bulletBoostTime && boostActive2 == false)
        {
            timer3 = 0;
            boostActive3 = false;
            boostActive2 = true;
            boostActive = true;
            GetComponent<OtherPlayerShootScirpt>().enabled = true;

        }
        if (currentPoints > bullet2NeededPoints && timer3 > bulletBoostLastingTime && boostActive3 == false)
        {
            timer2 = 0;
            boostActive3 = true;
            boostActive2 = false;
            boostActive = false;
            GetComponent<OtherPlayerShootScirpt>().enabled = false;
        }

        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > shootDelay && boostActive == false && currentPoints > bullet1NeededPoints)
        {
            timer = 0;
            GameObject bullet = Instantiate(theBullet, transform.position, transform.rotation);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 shootDir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = (shootDir * bulletSpeed) + GetComponentInParent<Rigidbody2D>().velocity;
            //bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            bullet.transform.up = shootDir;
            //Debug.Log(shootDir);
            Destroy(bullet, bulletlifetime);
        }
        if (Input.GetButton("Fire1") && timer > shootDelay && boostActive == false && currentPoints < bullet1NeededPoints)
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
            //bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            bullet.transform.up = shootDir;
            //Debug.Log(shootDir);
            Destroy(bullet, bulletlifetime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MassKillEnemies")
        {
            boostActive = false;
            GetComponent<OtherPlayerShootScirpt>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MassKillEnemies")
        {
            boostActive = false;
            GetComponent<OtherPlayerShootScirpt>().enabled = false;
        }
    }
}
