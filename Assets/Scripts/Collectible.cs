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
    public AudioClip ten;
    public AudioClip twenty;
    public AudioClip fifty;
    private AudioClip audio;
    public Rigidbody2D rb;
    public Collider2D map;
	// Use this for initialization
	void Start () {
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
        float current = Time.timeSinceLevelLoad;
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
    void OnCollisionEnter2D(Collision2D colliderInfo)
    {
        if (colliderInfo.collider.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audio, transform.position);
            string name = colliderInfo.collider.name;
            string codename = "";
            foreach( KeyValuePair<string, int> x in SaveState.PlayerScore)
            {
                if (name.CompareTo(x.Key) == 0)
                {
                    codename = x.Key;
                }
            }
            
            SaveState.PlayerScore[codename] += point;
            NextMap.currentCount++;
            Destroy(this.gameObject);

        }
    }
}
