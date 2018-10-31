using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDisplay : MonoBehaviour {

	// Use this for initialization
	void Update () {
        this.GetComponent<Text>().text = "Points to Spend:\n" + SaveState.MoneyScore;
	}
}
