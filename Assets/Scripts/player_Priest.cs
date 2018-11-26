using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Priest : PlayerControlSetup
{
    public override void usePowerUp()
    {
        powerUp = Resources.Load<AudioClip>("Audio/Powers/Curse02_Demon") as AudioClip;
        base.usePowerUp();
        if (isPowerUp)
        {
            string myName = "Player" + PlayerNum;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int x = 0; x < SaveState.howManyPlayers; x++)
            {
                string othername = players[x].name;
                if (othername.CompareTo(myName) != 0)
                    SaveState.PlayerScore[othername] -= (int)(SaveState.PlayerScore[othername] * 0.1); //subtract 10% of their coin value
                    players[x].GetComponent<PlayerControlSetup>().curse = true;
            }
        }
    }
}
