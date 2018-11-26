using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_BossLady : PlayerControlSetup {
    string myName;
    int currentScore; //capture score before powerup
    public override void usePowerUp()
    {
        powerDown = Resources.Load<AudioClip>("Audio/Powers/Boost02_Mage") as AudioClip;
        base.usePowerUp();
        string myName = "Player" + PlayerNum;
        int currentScore = SaveState.PlayerScore[myName];
        if (isPowerUp)
        {
            currentScore = SaveState.PlayerScore[myName];
            
        }
    }
    void fixScore()
    {
        int scoreAfterPowerUp = SaveState.PlayerScore[myName]; //score after powerup
        int valueToDouble = scoreAfterPowerUp - currentScore; //add double collected value to score
        SaveState.PlayerScore[myName] += valueToDouble; //add the coins collected back again to the score, thereby doubling value
    }
}
