using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public List<Transform> enemyList = new List<Transform>();
    public float respawnAfter = 2.0f;
    public float clearEnemiesFor = 3.0f;
    float clearEnemies;
    public int Health = 10;
    public int Lives = 10;
    int initialLives;
    int initialHealth;
    public float deathTimer;
    public Text healthText;
    public Text liveText;
    //public LevelManager levelManager;
    public GameObject deathParticle;
    public GameObject respawnParticles;
    GameObject MassKillEnemies;
    GameObject player;
    GameObject PlayerSprite;
    bool hasRespawned;
    bool massDestroy;


    private void Start()
    {

        initialLives = Lives;
        hasRespawned = true;
        massDestroy = false;
        PlayerSprite = GameObject.FindGameObjectWithTag("PlayerSprite");
        MassKillEnemies = GameObject.FindGameObjectWithTag("MassKillEnemies");
        player = GameObject.FindGameObjectWithTag("Player");
        MassKillEnemies.GetComponent<BoxCollider2D>().enabled = false;
        //Lives = PlayerPrefs.GetInt("Lives"); //Sets current Lives to what is stored in the Lives playerPrefs
        //PlayerPrefs.SetInt("Lives", Lives);
        initialHealth = Health;
        healthText.text = "HP: " + Health + "/" + initialHealth;
        liveText.text = "LIVES: " + Lives;
        //levelManager = FindObjectOfType<LevelManager>();
    }
    private void Update()
    {
        clearEnemies += Time.deltaTime;
        deathTimer += Time.deltaTime;
        if (deathTimer > respawnAfter && Health >= 0 && hasRespawned == false)
        {
            hasRespawned = true;
            Instantiate(respawnParticles, player.transform.position, player.transform.rotation);
            Health = initialHealth;
            healthText.text = "HEALTH: " + Health + "/" + initialHealth;
            PlayerSprite.GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<PlayerMovement>().enabled = true;
            GetComponentInChildren<PlayShoot>().enabled = true;
            //MassKillEnemies.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (clearEnemies > clearEnemiesFor && massDestroy == true)
        {
            MassKillEnemies.GetComponent<BoxCollider2D>().enabled = false;
            massDestroy = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyShoot" || collision.gameObject.tag == "Enemy")
        {
            gethurt();

            if (Health < 1)
            {
                deathTimer = 0;
                respawnplayer();
                loselife();

                if (Lives < 0)
                {
                    //SceneManager.LoadScene("GameOver");
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.tag == "Coin")
        {
            getheart();
            Destroy(collision.gameObject);
            if(Health >= initialHealth)
            {
                Health = initialHealth;
                healthText.text = "HP: " + Health + "/" + initialHealth;
            }
        }
        }
    void loselife()
    {
        Lives--;
        liveText.text = "LIVES: " + Lives;
        //Health = initialHealth;
    }
    void gethurt()
    {
        Health--;
        healthText.text = "HP: " + Health + "/" + initialHealth;
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
    }
    void respawnplayer()
    {
        clearEnemies = 0;
        massDestroy = true;
        hasRespawned = false;
        PlayerSprite.GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponentInChildren<PlayShoot>().enabled = false;
        MassKillEnemies.GetComponent<BoxCollider2D>().enabled = true;

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        healthText.text = "HEALTH: " + Health + "/" + initialHealth;
    }
    void getheart()
    {
        Health++;
        healthText.text = "HEALTH: " + Health + "/" + initialHealth;
    }
}
