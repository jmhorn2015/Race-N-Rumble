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
        else
        {
                Debug.Log("no type selected");
        }
        gameObject.GetComponent<PlayerControlSetup>().AddPlayerNum(PlayNum);
    }
}
