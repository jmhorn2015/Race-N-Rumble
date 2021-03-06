﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script Writer: Jenna Horn

public class ScoreShow : MonoBehaviour {
    private Text display;
	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        string score = "Results: \n";
        score += SaveState.DisplayScoreofPlayer();
        display = this.gameObject.GetComponent<Text>();
        display.text = score;
        SaveState.MapList = new List<string>();
        SaveState.MapCounter = 0;
        SaveState.isQueen = false;
	}
}
