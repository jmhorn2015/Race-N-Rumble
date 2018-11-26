using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script Writer: Jenna Horn

public class StartGame : MonoBehaviour {
    // Update is called once per frame
    private bool inTransition = false;
    public int MapMin;
    public static int MapMax;
	void Update () {
        if(ConfirmDisplay.counter == SaveState.howManyPlayers && inTransition == false)
        {
            inTransition = true;
            Invoke("SendToMaps", 1);
        }
        Debug.Log(MapMax);
		
	}
    void SendToMaps()
    {
        List<SaveState.PlayerState> array = new List<SaveState.PlayerState>();
        for (int x = 1; x <= SaveState.howManyPlayers; x++)
        {
            string name = "Player" + x;
            foreach (SaveState.PlayerState y in SaveState.Players)
            {
                if (y.Name.CompareTo(name) == 0)
                {
                    array.Add(y);
                }
            }
        }
        SaveState.Players = array;
        inTransition = false;
        ConfirmDisplay.confirmBools = new bool[SaveState.howManyPlayers];
        ConfirmDisplay.counter = 0;
        SaveState.PowerUpLeft = new int[] { 3, 3, 3, 3 };
        for (int x = MapMin; x<=MapMax; x++)
        {
            string tempName = "Map " + x;
            SaveState.MapList.Add(tempName);
        }
        SaveState.MapList.TrimExcess();
        SceneManager.LoadScene(SaveState.MapList[0]);

    }
}
