using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script Writer: Jenna Horn

public class Collectible : MonoBehaviour {
    private int pointB = 10;
    private int pointS = 20;
    private int pointG = 50;
    private int point = 0;
    private float stuck = .05f;
    private bool isVisable = false;
    private Vector2 lastPos;
    private Vector2 textPos;
    private Vector2 camDelta;
    private string pointText;
    private AudioClip ten;
    private AudioClip twenty;
    private AudioClip fifty;
    public  AudioClip audio;
    public Rigidbody2D rb;
    public Collider2D map;
	// Use this for initialization
	void Start () {
        pointText = "";
        camDelta.x = GameObject.FindObjectOfType<Camera>().scaledPixelWidth / 19.2f;
        camDelta.y = GameObject.FindObjectOfType<Camera>().scaledPixelHeight / 10.8f;
        ten = Resources.Load<AudioClip>("Audio/SE/Coin2") as AudioClip;
        twenty = Resources.Load<AudioClip>("Audio/SE/Coin1") as AudioClip;
        fifty = Resources.Load<AudioClip>("Audio/SE/Coin3") as AudioClip;
        int temp = (int)Random.Range(0f, 100f);
        if (temp <= 5)
        {
            point = pointG;
            audio = fifty;
        }
        else if (temp <= 25)
        {
            point = pointS;
            audio = twenty;
        }
        else
        {
            point = pointB;
            audio = ten;
        }
        rb.constraints = RigidbodyConstraints2D.None;
        Vector2 pos;
        do
        {
            pos.x = Random.Range(0f, (float)16.5) - 8.25f;
            pos.y = Random.Range(0f, (float)8.5) - 4.25f;
            rb.position = pos;
        }
        while (this.gameObject.GetComponent<Collider2D>().IsTouchingLayers(Physics2D.AllLayers));
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        lastPos = pos;
        this.gameObject.GetComponent<Renderer>().enabled = false;
    }

	void Update()
    {
        if (SaveState.isQueen)
        {
            audio = Resources.Load<AudioClip>("Audio/SE/FobiddenCoin") as AudioClip;
        }
        float current = Time.timeSinceLevelLoad;
        textPos.x = (transform.position.x + 9.6f)*camDelta.x - 8.5f;
        textPos.y = (-transform.position.y + 5.4f)*camDelta.y - 17f;

        if (current >= stuck && lastPos.y - rb.position.y <= .35)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            lastPos.x = Random.Range(0f, (float)16.5) - 8.25f;
            lastPos.y = Random.Range(0f, (float)8.5) - 4.25f;
            rb.position = lastPos;
            stuck += .1f;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else if(current >= stuck && isVisable == false)
        {
            isVisable = true;
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
    void OnGUI()
    {

        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 30;
        myStyle.normal.textColor = Color.black;
        GUI.Label(new Rect(textPos.x, textPos.y, 100f, 20f), pointText , myStyle);
    }
    void DestroyCoin()
    {
        Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D colliderInfo) //Here is the function you need to edit in
    {
        if (colliderInfo.collider.tag == "Player" & isVisable == true)
        {
            AudioSource.PlayClipAtPoint(audio, new Vector2(0f,0f));
            string name = colliderInfo.collider.name;
            string codename = "";
            foreach( KeyValuePair<string, int> x in SaveState.PlayerScore)
            {
                if (name.CompareTo(x.Key) == 0)
                {
                    codename = x.Key;
                }
            }
            pointText = point.ToString();
            SaveState.PlayerScore[codename] += point;
            NextMap.currentCount++;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("DestroyCoin", 2f);
        }
    }
}
