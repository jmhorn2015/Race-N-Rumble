using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Veteran : PlayerControlSetup
{
    override public void usePowerUp()
    {
        powerUp = Resources.Load<AudioClip>("Audio/Powers/Speed03_Ninja") as AudioClip;
        base.usePowerUp();
        Debug.Log("Using PowerUp...");
        //powerup is activated for powerup_length_seconds, which is set to 5 seconds by default.
        if (isPowerUp)
        {
            speedCheck = speedCheck*2;
            Invoke("EndPU", 5f);
        }
    }
    void EndPU()
    {
        speedCheck = orig_speed;
    }
}
