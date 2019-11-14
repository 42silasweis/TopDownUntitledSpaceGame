using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollect1 : MonoBehaviour
{
    public int Points = 0;
    public int pointCount = 0;
    public int healthUpPoints = 300000;
    public int pointsAdded = 50000;
    //public int lifeUpPoints = 300000;
    public GameObject healthPackDrop;
    int initialCoins = 0;
    public Text pointsText;
    public Text multiplierText;
    public int pointMultiplier;
    public int maxMultiplier = 100;
    string Points1;
    int prefPoints1;
    public int Level = 1;

    bool dropInstantiated = false;
    bool timerDone = true;

    float dropDelay = 0.5f;
    float droptimer;

    int playerLives;
    float playerHealth;

    void Start()
    {
        pointsText.text = "SCORE: " + Points;
        multiplierText.text = "x" + pointMultiplier;

        //prefPoints1 = PlayerPrefs.GetInt("Lvl1Score");
        switch (Level)
        {
            case 5:
                prefPoints1 = PlayerPrefs.GetInt("Lvl5Score");
                break;
            case 4:
                prefPoints1 = PlayerPrefs.GetInt("Lvl4Score");
                break;
            case 3:
                prefPoints1 = PlayerPrefs.GetInt("Lvl3Score");
                break;
            case 2:
                prefPoints1 = PlayerPrefs.GetInt("Lvl2Score");
                break;
            case 1:
                prefPoints1 = PlayerPrefs.GetInt("Lvl1Score");
                break;
        }
    }

    void Update()
    {
        playerHealth = GetComponent<PlayerHP>().Health;
        playerLives = GetComponent<PlayerHP>().Lives;

        droptimer += Time.deltaTime;
        if (droptimer > dropDelay && timerDone == false)
        {
            timerDone = true;
            dropInstantiated = false;
        }

        if (pointCount >= healthUpPoints && playerHealth < 1 && dropInstantiated == false || pointCount >= healthUpPoints && playerLives < 5 && dropInstantiated == false)
        {
            healthUpPoints += pointsAdded;
            timerDone = false;
            dropInstantiated = true;
            droptimer = 0;
            pointCount = 0;
            Instantiate(healthPackDrop, transform.position, Quaternion.identity);
            Debug.Log("HealthPack Works");
        }
        //if (pointCount >= healthUpPoints && playerHealth == 1 && dropInstantiated == false || pointCount >= healthUpPoints && playerLives >= 5 && dropInstantiated == false)
        else
        {
            //timerDone = false;
            //pointCount = 0;
            //droptimer = 0;
        }

        Points1 = Points.ToString("#,##0");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        prefPoints1 = PlayerPrefs.GetInt("Lvl1Score");
        Debug.Log(prefPoints1);
        if (Points > prefPoints1)
        {
        PlayerPrefs.SetInt("Lvl1Score", Points);
        }
        */

        switch (Level)
        {
            case 5:
                prefPoints1 = PlayerPrefs.GetInt("Lvl5Score");
                if (Points > prefPoints1)
                {
                    PlayerPrefs.SetInt("Lvl5Score", Points);
                }
                break;
            case 4:
                prefPoints1 = PlayerPrefs.GetInt("Lvl4Score");
                if (Points > prefPoints1)
                {
                    PlayerPrefs.SetInt("Lvl4Score", Points);
                }
                break;
            case 3:
                prefPoints1 = PlayerPrefs.GetInt("Lvl3Score");
                if (Points > prefPoints1)
                {
                    PlayerPrefs.SetInt("Lvl3Score", Points);
                }
                break;
            case 2:
                prefPoints1 = PlayerPrefs.GetInt("Lvl2Score");
                if (Points > prefPoints1)
                {
                    PlayerPrefs.SetInt("Lvl2Score", Points);
                }
                break;
            case 1:
                prefPoints1 = PlayerPrefs.GetInt("Lvl1Score");
                if (Points > prefPoints1)
                {
                    PlayerPrefs.SetInt("Lvl1Score", Points);
                }
                break;
        }
        //This gives the player a set multiplier
        if (collision.gameObject.tag == "PointMultiplier")
        {
            if (pointMultiplier >= maxMultiplier)
            {
                pointMultiplier = maxMultiplier;
                Destroy(collision.gameObject);
            }
            else
            {
                pointMultiplier++;
                multiplierText.text = "x " + pointMultiplier;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "Plus5Points")
        {
            if (Points == 0)
            {
                Points += 5;
                pointCount += 5;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
            if (pointMultiplier == 0)
            {
                Points += 5;
                pointCount += 5;
                pointsText.text = "SCORE: " + Points1;
                Destroy(collision.gameObject);
            }
            else
            {
                Points += 5 * pointMultiplier;
                pointCount += 5 * pointMultiplier;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Plus10Points")
        {
            if (Points == 0)
            {
                Points += 10;
                pointCount += 10;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
            if (pointMultiplier == 0)
            {
                Points += 10;
                pointCount += 10;
                pointsText.text = "SCORE: " + Points1;
                Destroy(collision.gameObject);
            }
            else
            {
                Points += 10 * pointMultiplier;
                pointCount += 10 * pointMultiplier;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Plus20Points")
        {
            if (Points == 0)
            {
                Points += 20;
                pointCount += 20;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
            if (pointMultiplier == 0)
            {
                Points += 20;
                pointCount += 20;
                pointsText.text = "SCORE: " + Points1;
                Destroy(collision.gameObject);
            }
            else
            {
                Points += 20 * pointMultiplier;
                pointCount += 20 * pointMultiplier;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Plus40Points")
        {
            if (Points == 0)
            {
                Points += 40;
                pointCount += 40;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
            if (pointMultiplier == 0)
            {
                Points += 40;
                pointCount += 40;
                pointsText.text = "SCORE: " + Points1;
                Destroy(collision.gameObject);
            }
            else
            {
                Points += 40 * pointMultiplier;
                pointCount += 40 * pointMultiplier;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Plus80Points")
        {
            if (Points == 0)
            {
                Points += 80;
                pointCount += 80;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
            if (pointMultiplier == 0)
            {
                Points += 80;
                pointCount += 80;
                pointsText.text = "SCORE: " + Points1;
                Destroy(collision.gameObject);
            }
            else
            {
                Points += 80 * pointMultiplier;
                pointCount += 80 * pointMultiplier;
                pointsText.text = "SCORE: " + Points1; // + "/" + neededCoins;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "MassKillEnemies")
        {
            pointMultiplier = 0;
            multiplierText.text = "x" + pointMultiplier;
        }
    }
}
