using System.Collections;

using System.Collections.Generic;

using UnityEngine;


//Script writer: Rachel Alexander


public class player_Unicorn : PlayerControlSetup {
//the unicorn gets an immediate gold boost, using their magic unicorn powers
    public override void usePowerUp()
    {
        powerUp = Resources.Load<AudioClip>("Audio/Powers/unicorn") as AudioClip;
        base.usePowerUp();
        Debug.Log("using powerup");
        string name = "Player" + PlayerNum;
        SaveState.PlayerScore[name] += 25;
    }
}
