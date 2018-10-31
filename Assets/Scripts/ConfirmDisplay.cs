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
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            one = ConfirmFunct(one);
        }
        if (Input.GetKeyDown("e"))
        {
            two = ConfirmFunct(two);
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            three = ConfirmFunct(three);
        }
        if (Input.GetKeyDown("y"))
        {
            four = ConfirmFunct(four);
        }

        confirm.text = "Ready to go? " + counter + " Players";
        
    }
}
