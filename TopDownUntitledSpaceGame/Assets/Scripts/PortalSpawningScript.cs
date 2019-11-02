using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawningScript : MonoBehaviour
{
    GameObject player;
    int PointCount;
    public int neededPoints;
    public float timer;
    public float portalDelay;
    bool portalOn;
    bool portalOn2;
    public GameObject portalParticles;
    private SpriteRenderer spriteRenderer;
    public Sprite[] portalSprite;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        portalSprite = Resources.LoadAll<Sprite>("portal");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        PointCount = player.GetComponentInChildren<CoinCollect1>().Points;
        //Debug.Log(PointCount);

        if(PointCount > neededPoints && portalOn == false)
        {
            portalOn = true;
            timer = 0;
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Animator>().enabled = true;
            spriteRenderer.sprite = portalSprite[0];
        }
            if(PointCount > neededPoints && timer > portalDelay && portalOn2 == false)
            {
                portalOn2 = true;
                Instantiate(portalParticles, transform.position, transform.rotation);
                spriteRenderer.sprite = portalSprite[6];
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Animator>().enabled = false;
            }
    }
}
