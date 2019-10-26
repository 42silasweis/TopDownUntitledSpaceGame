using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public List<Transform> enemyList = new List<Transform>();
    public int Health = 10;
    public int Lives = 10;
    public int initialLives = 10;
    int initialHealth;
    public Text healthText;
    public Text liveText;
    //public Slider healthSlider;
    //public LevelManager levelManager;
    public GameObject deathParticle;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Lives = PlayerPrefs.GetInt("Lives"); //Sets current Lives to what is stored in the Lives playerPrefs
        //PlayerPrefs.SetInt("Lives", Lives);
        initialHealth = Health;
        //healthSlider.maxValue = Health;
        //healthSlider.value = Health;
        healthText.text = "HP: " + Health + "/" + initialHealth;
        liveText.text = "LIVES: " + Lives;
        //levelManager = FindObjectOfType<LevelManager>();
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
                //healthSlider.value = Health;
                healthText.text = "HP: " + Health + "/" + initialHealth;
            }
        }

        if (collision.gameObject.tag == "EnemyShoot" || collision.gameObject.tag == "Enemy")
            {
            gethurt();
                    if (Health < 1)
                    {
                    loselife();

                        if (Lives < 0)
                        {
                            SceneManager.LoadScene("GameOver");
                        }
                        else
                        {
                        respawnplayer();
                        }
                    }
            }
        }
    void loselife()
    {
        Lives--;
        //PlayerPrefs.SetInt("Lives", Lives);
        liveText.text = "LIVES: " + Lives;
        Health = initialHealth;
    }
    void gethurt()
    {
        Health--;
        //healthSlider.value = Health;
        healthText.text = "HP: " + Health + "/" + initialHealth;
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
    }
    void respawnplayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //healthSlider.value = Health;
        healthText.text = "HEALTH: " + Health + "/" + initialHealth;
    }
    void getheart()
    {
        Health++;
        //healthSlider.value = Health;
        healthText.text = "HEALTH: " + Health + "/" + initialHealth;
    }
}
