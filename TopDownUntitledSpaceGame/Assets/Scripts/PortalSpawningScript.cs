using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PortalSpawningScript : MonoBehaviour
{
    GameObject player;
    int PointCount;
    public int neededPoints;
    float timer;
    public float portalTimer;
    public float timeBeforeTP = 2.0f;
    public float portalDelay;
    bool portalOn = false;
    bool portalOn2 = false;
    public GameObject portalParticles;
    GameObject boss;
    private SpriteRenderer spriteRenderer;
    public Sprite[] portalSprite;

    int Level;

    bool sliderSpriteOn = false;
    Slider sliderBar;
    GameObject sliderBar1;
    GameObject sliderBar2;

    int isLevel4Complete;
    // Start is called before the first frame update
    void Start()
    {
        isLevel4Complete = PlayerPrefs.GetInt("Lvl4Complete");
        sliderBar = GameObject.FindGameObjectWithTag("PortalTimerSlider").GetComponent<Slider>();
        sliderBar1 = GameObject.FindGameObjectWithTag("PortalSliderBackground");
        sliderBar2 = GameObject.FindGameObjectWithTag("PortalSliderFill");
        sliderBar1.GetComponent<Image>().enabled = false;
        sliderBar2.GetComponent<Image>().enabled = false;
        sliderBar.maxValue = timeBeforeTP;
        sliderBar.value = portalTimer;

        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        portalSprite = Resources.LoadAll<Sprite>("portal");

        player = GameObject.FindGameObjectWithTag("Player");
        Level = player.GetComponentInChildren<CoinCollect1>().Level;

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
            if(portalOn == true && timer > portalDelay && portalOn2 == false)
            {
                portalOn2 = true;
                Instantiate(portalParticles, transform.position, transform.rotation);
                spriteRenderer.sprite = portalSprite[6];
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Animator>().enabled = false;
                //Debug.Log(portalOn2);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            portalTimer += Time.deltaTime;
            sliderBar.value = portalTimer;
            if (sliderSpriteOn == false)
            {
                sliderSpriteOn = true;
                sliderBar1.GetComponent<Image>().enabled = true;
                sliderBar2.GetComponent<Image>().enabled = true;
            }
        }
        if (collision.gameObject.tag == "Player" && portalTimer > timeBeforeTP)
        {
            if (Level == 4 && isLevel4Complete == 0) //If the player is completing level 4 for the first time you go to the Win scene 
            {                                        //if it is not the first time completing level 4 you go back to Level Select
                SceneManager.LoadScene("Win");
                PlayerPrefs.SetInt("Lvl4Complete", 1);
            }
            else
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            portalTimer = 0;
            sliderBar1.GetComponent<Image>().enabled = false;
            sliderBar2.GetComponent<Image>().enabled = false;
            sliderSpriteOn = false;
        }
    }
}
