using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script Writer: Jenna Horn

public class Start : MonoBehaviour {
    // Update is called once per frame
    private bool inTransition = false;
    public int MapMin;
    public int MapMax;
	void Update () {
        if(ConfirmDisplay.counter == 4 && inTransition == false)
        {
            inTransition = true;
            Invoke("SendToMaps", 1);
        }
		
	}
    void SendToMaps()
    {
        List<SaveState.PlayerState> array = new List<SaveState.PlayerState>();
        for(int x = 1; x<5; x++)
        {
            string name = "Player" + x;
            foreach(SaveState.PlayerState y in SaveState.Players)
            {
                Debug.Log("Player run in start");
                if(y.Name.CompareTo(name) == 0)
                {
                    array.Add(y);
                }
            }
        }
        SaveState.Players = array;
        inTransition = false;
        ConfirmDisplay.one = false;
        ConfirmDisplay.two = false;
        ConfirmDisplay.three = false;
        ConfirmDisplay.four = false;
        ConfirmDisplay.counter = 0;
        for (int x = MapMin; x<=MapMax; x++)
        {
            string tempName = "Map " + x;
            SaveState.MapList.Add(tempName);
        }
        SaveState.MapList.TrimExcess();
        SceneManager.LoadScene(SaveState.MapList[0]);

    }
}
