using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//by Rachel Alexander
public class player_Demon : PlayerControlSetup
{
    //Script by Rachel Alexander
    //the demon will steal all the coins from the closest player

    private GameObject findClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = this.transform.position;
        foreach (GameObject player in players)
        {
            if (player.name.Equals("Player1") ||
                player.name.Equals("Player2") ||
                player.name.Equals("Player3") ||
                player.name.Equals("Player4"))
            {
                Vector3 diff = player.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (!player.transform.position.Equals(position) && curDistance < distance)
                {
                    closest = player;
                    distance = curDistance;
                }

            }
        }
        return closest;
    }

    override public void usePowerUp()
    {
        powerUp = Resources.Load<AudioClip>("Audio/Powers/Curse01_Demon") as AudioClip;
        base.usePowerUp();
        if (isPowerUp)
        {
            GameObject closestPlayer = findClosestPlayer();
            closestPlayer.GetComponent<PlayerControlSetup>().curse = true;
            Debug.Log("Closest player is " + closestPlayer.name);

            //steal from closest player
            int closestPlayerScore = SaveState.PlayerScore[closestPlayer.name];
            SaveState.PlayerScore[closestPlayer.name] = 0;

            //add what you stole to your total
            string myname = "Player" + PlayerNum;
            SaveState.PlayerScore[myname] += closestPlayerScore;
            closestPlayerScore = 0;
        }
    }
}
