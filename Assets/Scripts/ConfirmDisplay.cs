using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script Writer: Jenna Horn 

public class ConfirmDisplay : MonoBehaviour {
    private Text confirm;
    public static bool one, two, three, four;
    public static int counter;
	// Use this for initialization
	void Start () {
        confirm = this.gameObject.GetComponent<Text>();
        one = false;
        two = false;
        three = false;
        four = false;
	}
	bool ConfirmFunct(bool x)
    {
        x = !x;
        if (x)
        {
            counter++;
        }
        else
        {
            counter--;
        }
        return x;
    }
	// Update is called once per frame
	void Update () {
        if (InputManager.Power(1))
        {
            one = ConfirmFunct(one);
        }
        if (InputManager.Power(2))
        {
            two = ConfirmFunct(two);
        }
        if (InputManager.Power(3))
        {
            three = ConfirmFunct(three);
        }
        if (InputManager.Power(4))
        {
            four = ConfirmFunct(four);
        }

        confirm.text = "Ready to go? " + counter + " Players";
        
    }
}
