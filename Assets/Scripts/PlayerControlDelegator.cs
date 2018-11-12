using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlDelegator : MonoBehaviour {
    public int PlayNum;
    // Use this for initialization
    void Start() {
        string type = SaveState.Players[PlayNum - 1].Attack;
        if (type.CompareTo("Fighter") == 0) {
            gameObject.AddComponent<player_Fighter>();
        }
        else if (type.CompareTo("Dragon") == 0) {
            gameObject.AddComponent<player_Dragon>();
        }
        else if (type.CompareTo("Alien") == 0) {
            gameObject.AddComponent<player_Alien>();
        }
        else if (type.CompareTo("Demon") == 0)
        {
            gameObject.AddComponent<player_Demon>();
        }
        else if (type.CompareTo("Mage") == 0)
        {
            gameObject.AddComponent<player_Mage>();
        }
        else if (type.CompareTo("Elf") == 0)
        {
            gameObject.AddComponent<player_Elf>();
        }
        else if (type.CompareTo("Priest") == 0)
        {
            gameObject.AddComponent<player_Priest>();
        }
        else if (type.CompareTo("Veteran") == 0)
        {
            gameObject.AddComponent<player_Veteran>();
        }
        else if (type.CompareTo("Ninja") == 0)
        {
            gameObject.AddComponent<player_Ninja>();
        }
        else if (type.CompareTo("Boss Lady") == 0)
        {
            gameObject.AddComponent<player_BossLady>();
        }
        else if (type.CompareTo("Unicorn") == 0)
        {
            gameObject.AddComponent<player_Unicorn>();
        }
        else if (type.CompareTo("Queen") == 0)
        {
            gameObject.AddComponent<player_Queen>();
        }
        else
        {
                Debug.Log("no type selected");
        }
        gameObject.GetComponent<PlayerControlSetup>().AddPlayerNum(PlayNum);
    }
}
