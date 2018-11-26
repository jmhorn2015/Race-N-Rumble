using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script Writer: Jenna Horn 

public class ConfirmDisplay : MonoBehaviour {
    private Text confirm;
    public static bool[] confirmBools;
    public static int counter;
	// Use this for initialization
	void Start () {
        confirm = this.gameObject.GetComponent<Text>();
        confirmBools = new bool[SaveState.howManyPlayers];
	}
	void ConfirmFunct(int x)
    {
        confirmBools[x] = !confirmBools[x];
        if (confirmBools[x])
        {
            counter++;
        }
        else
        {
            counter--;
        }
    }
	// Update is called once per frame
	void Update () {
        foreach (bool x in confirmBools)
        {
            Debug.Log(x);
        }
        if (InputManager.Power(1))
        {
            ConfirmFunct(0);
        }
        if (InputManager.Power(2))
        {
            ConfirmFunct(1);
        }
        if (InputManager.Power(3) & SaveState.howManyPlayers >= 3)
        {
            ConfirmFunct(2);
        }
        if (InputManager.Power(4) & SaveState.howManyPlayers >= 4)
        {
            ConfirmFunct(3);
        }

        confirm.text = "Ready to go? " + counter + " Players";
        
    }
}
