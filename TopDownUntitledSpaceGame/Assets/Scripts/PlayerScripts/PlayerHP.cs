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
    public float Health = 1.0f;
    public int Lives = 10;
    int initialLives;
    float initialHealth;
    public float deathTimer;
    public Text healthText;
    public Slider healthSlider;
    public Text liveText;
    public GameObject deathParticle;
    public GameObject respawnParticles;
    public GameObject respawnSound;
    public GameObject playerDeathSound;
    GameObject MassKillEnemies;
    GameObject player;
    GameObject PlayerSprite;
    bool hasRespawned;
    bool massDestroy;
    bool firstRespawn;


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
        healthText.text = "HEALTH: " + Health;// + "/" + initialHealth;
        healthSlider.maxValue = Health;
        healthSlider.value = Health;
        //liveText.text = "LIVES: " + Lives;
        liveText.text = "" + Lives;
        //levelManager = FindObjectOfType<LevelManager>();

        //Make the player "Spawn" when starting the game
        deathTimer = 1;
        firstRespawn = false;
        PlayerSprite.GetComponentInChildren<SpriteRenderer>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        GetComponentInChildren<PlayShoot>().enabled = false;
    }
    void Update()
    {
        clearEnemies += Time.deltaTime;
        deathTimer += Time.deltaTime;
        //Make the player "Spawn" when starting the game part 2 the if statement part to turn everything back on
        if (deathTimer > respawnAfter && firstRespawn == false)
        {
            firstRespawn = true;
            Instantiate(respawnParticles, player.transform.position, player.transform.rotation);
            Instantiate(respawnSound, player.transform.position, player.transform.rotation);
            Health = initialHealth;
            healthText.text = "HEALTH: " + Health;// + "/" + initialHealth;
            healthSlider.value = Health;
            PlayerSprite.GetComponentInChildren<SpriteRenderer>().enabled = true;
            //GetComponent<PolygonCollider2D>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
            GetComponentInChildren<PlayShoot>().enabled = true;
        }
        //Makes player "Respawn" after getting hit
        if (deathTimer > respawnAfter && Health <= 0 && hasRespawned == false)
        {
            //GetComponentInChildren<PlayShoot>().enabled = true;
            hasRespawned = true;
            Instantiate(respawnParticles, player.transform.position, player.transform.rotation);
            Instantiate(respawnSound, player.transform.position, player.transform.rotation);
            Health = initialHealth;
            healthText.text = "HEALTH: " + Health;// + "/" + initialHealth;
            healthSlider.value = Health;
            PlayerSprite.GetComponentInChildren<SpriteRenderer>().enabled = true;
            //GetComponent<PolygonCollider2D>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
        }

        if (clearEnemies > clearEnemiesFor && massDestroy == true)
        {
            MassKillEnemies.GetComponent<BoxCollider2D>().enabled = false;
            massDestroy = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HealthPack")
        {
            if(Health == 0.5)
            {
                Health = initialHealth;
                healthText.text = "HEALTH: " + Health;
                healthSlider.value = Health;
                Destroy(collision.gameObject);
            }

            if (Health == initialHealth)
            {
                if (Lives < initialLives)
                {
                    Lives++;
                    liveText.text = "" + Lives;
                    Destroy(collision.gameObject);
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnBullet") //Player only loses 0.5 of their 1 HP
        {
            gethurthalf();
            if (Health <= 0)
            {
                deathTimer = 0;
                respawnplayer();
                loselife();

                if (Lives < 0)
                {
                    Lives = 0;
                    liveText.text = "" + Lives;
                    SceneManager.LoadScene("Lose");
                    //SceneManager.LoadScene("GameOver");
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
            {
                gethurt();

                if (Health <= 0)
                {
                    respawnplayer();
                    loselife();

                    if (Lives < 0)
                    {
                        Lives = 0;
                        liveText.text = "" + Lives;
                        SceneManager.LoadScene("Lose");
                        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            }
    }
        void loselife()
        {
            Lives--;
            //liveText.text = "LIVES: " + Lives;
            liveText.text = "" + Lives;
            //Health = initialHealth;
    }
    void gethurthalf()
    {
        Health -= 0.5f;
        healthText.text = "HEALTH: " + Health;// + "/" + initialHealth;
        healthSlider.value = Health;
        //Instantiate(deathParticle, player.transform.position, player.transform.rotation);
    }
    void gethurt()
    {
        Health--;
        healthText.text = "HEALTH: " + Health;// + "/" + initialHealth;
        healthSlider.value = Health;
        //Instantiate(deathParticle, player.transform.position, player.transform.rotation);
    }
        void respawnplayer()
        {
            deathTimer = 0;
            clearEnemies = 0;
            massDestroy = true;
            hasRespawned = false;
            PlayerSprite.GetComponentInChildren<SpriteRenderer>().enabled = false;
            //GetComponent<PolygonCollider2D>().enabled = false;
            player.GetComponentInParent<PlayerMovement>().enabled = false;
            //GetComponentInChildren<PlayShoot>().enabled = false;
            //GetComponentInChildren<OtherPlayerShootScirpt>().enabled = false;
            MassKillEnemies.GetComponent<BoxCollider2D>().enabled = true;
            healthText.text = "HEALTH: " + Health;// + "/" + initialHealth;
            healthSlider.value = Health;
            Instantiate(deathParticle, player.transform.position, player.transform.rotation);
            Instantiate(playerDeathSound, player.transform.position, player.transform.rotation);
    }
    }
