using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script Writer: Jenna Horn

public class NextMap : MonoBehaviour {
    public int HowManyCollectibles;
    public static int currentCount = 0;
	// Update is called once per frame
	void Update () {
		if ((currentCount > HowManyCollectibles - 1) && (SaveState.MapCounter < SaveState.MapList.Capacity))
        {
            currentCount = 0;
            Invoke("toNextMap", 1f);
        }
        else if(SaveState.MapCounter >= SaveState.MapList.Capacity)
        {
            Invoke("toResults", 1f);
        }
	}
    void toNextMap()
    {
        SaveState.MapCounter++;
        if (SaveState.MapCounter < SaveState.MapList.Capacity)
        {
            SceneManager.LoadScene(SaveState.MapList[SaveState.MapCounter]);
        }
    }
    void toResults()
    {
        SceneManager.LoadScene("Results Menu");
    }
}