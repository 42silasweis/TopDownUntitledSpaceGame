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
    //public GameObject deathSound;

    public GameObject SoundManager;
    AudioSource SoundSource;
    public AudioClip deathAudio;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager = GameObject.FindGameObjectWithTag("SoundManager");
        SoundSource = SoundManager.GetComponent<AudioSource>();
    }
    void Update()
    {
        if(SoundManager == null || SoundSource == null)
        {
            SoundManager = GameObject.FindGameObjectWithTag("SoundManager");
            SoundSource = SoundManager.GetComponent<AudioSource>();
        }
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
        if (collision.gameObject.tag == "PBullet" || collision.gameObject.tag == "PBulletParent")
        {
            enemyHealth--;
            Instantiate(deathParticle, transform.position, transform.rotation);

            if (objectInstantiated == false && enemyHealth <= 0)
            {
                if (SoundSource != null)
                {
                SoundSource.PlayOneShot(deathAudio, 0.5F);
                }
                //Instantiate the object;
                GameObject droppedPointMultiplier = Instantiate(pointMultiplier, transform.position, transform.rotation);
                Instantiate(points, transform.position, Quaternion.identity);
                droppedPointMultiplier.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
                objectInstantiated = true;
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "MassKillEnemies")
        {
            enemyHealth--;
            Instantiate(deathParticle, transform.position, transform.rotation);
            //Instantiate(deathSound, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
