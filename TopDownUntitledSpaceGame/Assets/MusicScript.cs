using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    //public AudioSource _AudioSource1;
    //public AudioSource _AudioSource2;

    public float bossMusicDelay = 90.0f;
    float timer;
    public int pointsNeeded;
    int pointCount;
    GameObject player;

    public AudioSource _AudioSource;

    public AudioClip _AudioClip1;
    public AudioClip _AudioClip2;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _AudioSource.clip = _AudioClip1;
        _AudioSource.Play();

        //_AudioSource1.Play();
        //_AudioSource2.Stop();
    }
    void Update()
    {
        timer += Time.deltaTime;
        pointCount = player.GetComponentInChildren<CoinCollect1>().Points;

        if (timer >= bossMusicDelay && pointCount >= pointsNeeded)
        {
            _AudioSource.clip = _AudioClip2;
            _AudioSource.Play();

            //_AudioSource1.Stop();
            //_AudioSource2.Play();
            /*
            if (_AudioSource1.isPlaying)
            {
                _AudioSource1.Stop();
                _AudioSource2.Play();
            }
            else
                _AudioSource2.Stop();
                _AudioSource1.Play();
        }
            {*/
        }
    }
}
