using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Fighter: PlayerControlSetup {
    //add implementation for attacks and powerups latahhh
    public override void usePowerUp()
    {
        base.usePowerUp();
    }
    public void OnCollisionEnter2D(Collision2D info)
    {
        powerActive = Resources.Load<AudioClip>("Audio/Powers/Attack01_Fighter-2") as AudioClip;
        if (isPowerUp & info.collider.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(powerActive, new Vector2(0f, 0f));
            float player = gameObject.transform.position.x;
            float other = info.transform.position.x;
            if (player > other)
            {
                info.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 100f));
            }
            else
            {
                info.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 100f));
            }
        }
    }
}
