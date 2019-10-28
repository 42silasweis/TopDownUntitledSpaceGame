using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 6;
    public GameObject heart;
    public bool objectInstantiated;
    public GameObject deathParticle;
    // Start is called before the first frame update
    void Start()
    {

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
                GameObject dropheart = Instantiate(heart, transform.position, Quaternion.identity);
                dropheart.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
                objectInstantiated = true;
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
