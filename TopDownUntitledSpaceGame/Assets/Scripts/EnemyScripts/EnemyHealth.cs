using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 6;
    public bool objectInstantiated;
    public GameObject pointMultiplier;
    GameObject droppedPointMultiplier;
    public GameObject points;
    public GameObject deathParticle;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MassKillEnemies")
        {
            enemyHealth--;
            Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PBullet")
        {
            enemyHealth--;
            Instantiate(deathParticle, transform.position, transform.rotation);

            if (objectInstantiated == false && enemyHealth <= 0)
            {
                Destroy(gameObject);
                //Instantiate the object;
                GameObject droppedPointMultiplier = Instantiate(points, transform.position, Quaternion.identity);
                Instantiate(pointMultiplier, transform.position, Quaternion.identity);
                droppedPointMultiplier.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
                objectInstantiated = true;
            }
        }
        if (collision.gameObject.tag == "MassKillEnemies")
        {
            enemyHealth--;
            Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
