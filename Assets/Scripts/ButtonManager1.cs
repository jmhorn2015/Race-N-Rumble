using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager1 : MonoBehaviour {
    public static bool isContinue = false;
    AudioClip select;
    public void Start()
    {
        select = Resources.Load<AudioClip>("Audio/SE/Select") as AudioClip;
    }
    /* public void MapChanger(int x){     Code for Navya
     *  add 5 to x
     *  if x > 35, x = 10
     *  }
     *  
     *  public void AudioOnOff(Audio x){
     *  if x is playing, pause music on x
     *  if it is paused, play x
     *  }
     */

    public void NewGameBtn(string NewGameLevel)
    {
        StartCoroutine(PlaySelectNewGame(NewGameLevel));
    }
    public void ControlsBtn(string Controlspage)
    {
        StartCoroutine(PlaySelect(Controlspage));
    }
    public void MenuBtn(string Menupage)
    {
        StartCoroutine(PlaySelect(Menupage));
    }
    public void Quit()
    {
        StartCoroutine(PlaySelect());
        Application.Quit();
    }
    public void Reset(string x)
    {
        StartCoroutine(PlaySelect(x));
    }
    public void Hover()
    {
        AudioClip hover = Resources.Load<AudioClip>("Audio/SE/MoveCursor") as AudioClip;
        AudioSource.PlayClipAtPoint(hover, new Vector3(0, 0, 0));
    }
    IEnumerator PlaySelect()
    {
        AudioSource.PlayClipAtPoint(select, new Vector3(0,0,0));
        yield return new WaitForSeconds(select.length/4);
    }
    IEnumerator PlaySelectNewGame(string x)
    {
        AudioSource.PlayClipAtPoint(select, new Vector3(0, 0, 0));
        yield return new WaitForSeconds(select.length/4);
        if (isContinue & (SaveState.MapList.Capacity > 0 & SaveState.MapCounter > -1))
        {
            SceneManager.LoadScene(SaveState.MapList[SaveState.MapCounter]);
            isContinue = false;
        }
        else
        {
            SaveState.PlayerScore.Clear();
            SaveState.PlayerScore = new Dictionary<string, int>();
            SceneManager.LoadScene(x);
        }
    }
    IEnumerator PlaySelect(string x)
    {
            AudioSource.PlayClipAtPoint(select, new Vector3(0, 0, 0));
            yield return new WaitForSeconds(select.length/4);
        if (x.CompareTo("Character Lock") == 0)
        {
            for (int y = 2; y <= SaveState.maxCharaUnlocked; y++)
            {
                SaveState.AvailChara[y] = false;
            }
            SaveState.maxCharaUnlocked = 1;
        }
        else if (x.CompareTo("Map List") == 0)
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
        else
        {
            SceneManager.LoadScene(x);
        }
    }

}
