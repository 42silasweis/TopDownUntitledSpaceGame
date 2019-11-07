using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadGame : MonoBehaviour
{
    public Text timer;
    public float minutes = 5;
    public float seconds = 0;
    float miliseconds = 0;
    bool stop = false;

    void Update()
    {

        if (miliseconds <= 0)
        {
            if (seconds <= 0)
            {
                minutes--;
                seconds = 59;
            }
            else if (seconds >= 0)
            {
                seconds--;
            }

            miliseconds = 100;
        }

        miliseconds -= Time.deltaTime * 100;

        //Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
        timer.text = string.Format("{0}:{1}", seconds, (int)miliseconds);

        if (minutes <= 0 && seconds <= 0 && miliseconds <= 0)
        {
            stop = true;
            minutes = 0;
            seconds = 0;
            miliseconds = 0;
            SceneManager.LoadScene("LevelSelect");
        }
    }

    /*
    float timer = 0;
    public float restartGame = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= restartGame)
        {
            SceneManager.LoadScene("LevelSelect");
        }

    }*/
}
