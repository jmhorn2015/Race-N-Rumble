using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Ninja : PlayerControlSetup {
    //the Ninja can pass through other players without having to jump over them when their powerup is used, and they receive a small speed boost

    //by Rachel Alexander
    bool isNinjaPower;
    override public void usePowerUp()
    {
        powerUp = Resources.Load<AudioClip>("Audio/Powers/Speed01_Ninja") as AudioClip;
        base.usePowerUp();
        if (isPowerUp)
        {
            isNinjaPower = true;
            speedCheck = 7f;
            foreach(GameObject x in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (x.name.CompareTo(gameObject.name) != 0)
                {
                    Physics2D.IgnoreCollision(x.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
                }
            }
            Invoke("EndPU", 5f);
        }
    }

    void EndPU()
    {
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (x.name.CompareTo(gameObject.name) != 0)
            {
                Physics2D.IgnoreCollision(x.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), false);
            }
        }
        speedCheck = orig_speed;
    }
}
