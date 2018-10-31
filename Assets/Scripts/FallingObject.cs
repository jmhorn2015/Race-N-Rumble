using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Writer: Katherine Velasco

public class FallingObject : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll; //Edit by Jenna Horn
    }
	
	void OnTriggerEnter2D (Collider2D col)
	{
        if (col.gameObject.tag == "Player")
            rb.constraints = RigidbodyConstraints2D.None;  //Edit by Jenna Horn
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name.Equals ("Player"))
			Debug.Log ("Got you!");
	}

}
//https://www.youtube.com/watch?v=Me6G20rBXvQ
