using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager1 : MonoBehaviour {
    public static bool isContinue = false;
    public void NewGameBtn(string NewGameLevel)
    {
        Debug.Log(isContinue + "\n" + SaveState.MapCounter + "\n" + SaveState.MapList.Capacity);
        if (isContinue & (SaveState.MapList.Capacity > 0 & SaveState.MapCounter>-1))
        {
            SceneManager.LoadScene(SaveState.MapList[SaveState.MapCounter]);
            isContinue = false;
        }
        else
        {
            SaveState.PlayerScore.Clear();
            SaveState.PlayerScore = new Dictionary<string, int>();
            SceneManager.LoadScene(NewGameLevel);
        }
    }
    public void ControlsBtn(string Controlspage)
    {
        SceneManager.LoadScene(Controlspage);
    }
    public void MenuBtn(string Menupage)
    {
        SceneManager.LoadScene(Menupage);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Reset(string x)
    {
        if(x.CompareTo("Character Lock") == 0)
        {
            for( int y = 2; y<= SaveState.maxCharaUnlocked; y++)
            {
                SaveState.AvailChara[y] = false;
            }
            SaveState.maxCharaUnlocked = 1;
        }
        else if(x.CompareTo("Map List") == 0)
        {
            SaveState.MapList.Clear();
            SaveState.MapCounter = 0;
            SaveState.Players.Clear();
            SaveState.PlayerScore.Clear();
            isContinue = false;
        }
        else if (x.CompareTo("Points") == 0)
        {
            SaveState.MoneyScore = 0;
        }
    }
}
