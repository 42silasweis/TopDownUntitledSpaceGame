using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollect1 : MonoBehaviour
{
    public int Points = 0;
    int initialCoins = 0;
    public Text pointsText;
    public Text multiplierText;
    public int pointMultiplier;
    public int maxMultiplier = 100;

    void Start()
    {
        pointsText.text = "SCORE: " + Points;
        multiplierText.text = "MULTIPLIER: " + pointMultiplier;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //This gives the player a set multiplier
        if(collision.gameObject.tag == "PointMultiplier")
        {
            pointMultiplier++;
            Destroy(collision.gameObject);
            multiplierText.text = "MULTIPLIER: " + pointMultiplier;
            if (pointMultiplier >= maxMultiplier)
            {
                pointMultiplier = maxMultiplier;
            }
        }

        if (collision.gameObject.tag == "Plus5Points")
        {
            Points += 5 * pointMultiplier;
            pointsText.text = "SCORE: " + Points; // + "/" + neededCoins;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Plus10Points")
        {
            Points += 10 * pointMultiplier;
            pointsText.text = "SCORE: " + Points; // + "/" + neededCoins;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Plus20Points")
        {
            Points += 20 * pointMultiplier;
            pointsText.text = "SCORE: " + Points; // + "/" + neededCoins;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Plus40Points")
        {
            Points += 40 * pointMultiplier;
            pointsText.text = "SCORE: " + Points; // + "/" + neededCoins;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Plus80Points")
        {
            Points += 80 * pointMultiplier;
            pointsText.text = "SCORE: " + Points; // + "/" + neededCoins;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "MassKillEnemies")
        {
            pointMultiplier = 0;
            multiplierText.text = "MULTIPLIER: " + pointMultiplier;
        }

    }
}
