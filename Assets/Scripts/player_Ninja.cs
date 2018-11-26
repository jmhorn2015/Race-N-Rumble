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
            Invoke("EndPU", 5f);
        }
    }

    void EndPU()
    {
        isNinjaPower = false;
        speedCheck = orig_speed;
    }

    void OnCollision2DEnter(Collision2D collision)
    {
        if (isNinjaPower)
        {
            if (collision.gameObject.tag == "Player") //turn off collisions with other players if PowerUp is enabled
            {
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.GetComponent<Collider>());
            }
        }
    }
}
