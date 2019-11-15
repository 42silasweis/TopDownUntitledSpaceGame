using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthScript : MonoBehaviour
{
    public int enemyHealth = 6;
    public GameObject points;
    public GameObject winPoints;
    public GameObject deathParticle;
    //public GameObject deathSound;
    //public GameObject getHitSound;
    public GameObject portal;
    Slider healthSlider;
    int initialHealth;
    Slider sliderBar;
    GameObject sliderBar1;
    GameObject sliderBar2;
    GameObject sliderBarName;
    GameObject player;
    bool isDead = false;

    public float respawnDelay = 2;
    float respawnTimer;
    bool playerRespawned = true;

    public int Level = 1;

    GameObject SoundManager;
    AudioSource SoundSource;
    public AudioClip deathAudio;
    public AudioClip getHitAudio;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager = GameObject.FindGameObjectWithTag("SoundManager");
        SoundSource = SoundManager.GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");
        sliderBar = GameObject.Find("BossHealthSlider").GetComponent<Slider>();
        sliderBar1 = GameObject.FindGameObjectWithTag("SliderBackground");
        sliderBar2 = GameObject.FindGameObjectWithTag("SliderFill");
        sliderBarName = GameObject.FindGameObjectWithTag("BossName");

        healthSlider = sliderBar;
        sliderBar1.GetComponent<Image>().enabled = true;
        sliderBar2.GetComponent<Image>().enabled = true;
        sliderBarName.GetComponent<Text>().enabled = true;
        initialHealth = enemyHealth;
        healthSlider.maxValue = enemyHealth;
        healthSlider.value = enemyHealth;
        Level = player.GetComponentInChildren<CoinCollect1>().Level;
    }
    void Update()
    {
        respawnTimer += Time.deltaTime;
        if(respawnTimer > respawnDelay && playerRespawned == false)
        {
            playerRespawned = true;
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<Enemyshoot>().enabled = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PBullet") ;// || collision.gameObject.tag == "PBulletParent")
        {
            enemyHealth--;
            healthSlider.value = enemyHealth;
            Instantiate(points, transform.position, Quaternion.identity);
            SoundSource.PlayOneShot(getHitAudio, 0.5F);

            if (enemyHealth <= 0 && isDead == false)
            {
                isDead = true;
                //Instantiate the object;
                Instantiate(winPoints, transform.position, Quaternion.identity);
                Instantiate(deathParticle, transform.position, transform.rotation);
                SoundSource.PlayOneShot(deathAudio, 0.7F);
                Instantiate(portal, transform.position, Quaternion.identity);
                sliderBar1.GetComponent<Image>().enabled = false;
                sliderBar2.GetComponent<Image>().enabled = false;
                sliderBarName.GetComponent<Text>().enabled = false;
                switch (Level)
                {
                    case 5:
                        PlayerPrefs.SetInt("Lvl5Complete", 1);
                        break;
                    case 4:
                        //PlayerPrefs.SetInt("Lvl4Complete", 1);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("Lvl3Complete", 1);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("Lvl2Complete", 1);
                        break;
                    case 1:
                        PlayerPrefs.SetInt("Lvl1Complete", 1);
                        break;
                }
                        Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "MassKillEnemies")
        {
            respawnTimer = 0;
            playerRespawned = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Enemyshoot>().enabled = false;
        }
    }
}
