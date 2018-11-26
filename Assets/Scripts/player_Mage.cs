using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Mage: PlayerControlSetup {
    //Rachel Alexander
    //The mage curses the other players, causing them to move more slowly for 5 seconds
    GameObject[] players;
    override public void usePowerUp()
    {
        powerUp = Resources.Load<AudioClip>("Audio/Powers/Grow02_Veteran") as AudioClip;
        base.usePowerUp();
        Debug.Log("Using PowerUp...");
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {

           player.GetComponent<PlayerControlSetup>().speedCheck = 1;
        }
        speedCheck = orig_speed; //make sure their own speed isn't affected
        Invoke("EndPU", 5f);
    }
    public void EndPU()
    {
        Debug.Log("PowerUp has ended");
        //revert back to normal speeds
        foreach (GameObject player in players)
        {
           player.GetComponent<PlayerControlSetup>().speedCheck = orig_speed;
        }
    }
}
