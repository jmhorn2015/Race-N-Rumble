using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    string prevScene;
    bool inMenu;
    bool inMap;
    AudioClip menu;
    AudioClip playerselect;
    AudioClip inGame;
    AudioClip store;
    public AudioSource audioMusic;
	void Start () {
        menu = Resources.Load<AudioClip>("Audio/BGM/Title_Theme") as AudioClip;
        playerselect = Resources.Load<AudioClip>("Audio/BGM/PlayerSelect_Theme") as AudioClip;
        inGame = Resources.Load<AudioClip>("Audio/BGM/Stage1_Theme") as AudioClip;
        store = Resources.Load<AudioClip>("Audio/BGM/Shop_Theme") as AudioClip;
        audioMusic = gameObject.GetComponent<AudioSource>();
        prevScene = "Title Menu";
        inMenu = true;
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        string current = SceneManager.GetSceneAt(0).name;
        string currcut = current.Substring(0, 3);
        string prevcut = prevScene.Substring(0, 3);
        if (current.CompareTo(prevScene) != 0) {
    
            if(current.CompareTo("Player Select Menu") == 0)
            {
                inMenu = false;
                audioMusic.clip = playerselect;
                audioMusic.Play();
            }
            else if(current.CompareTo("Store Menu") == 0)
            {
                inMenu = false;
                audioMusic.clip = store;
                audioMusic.Play();
            }
            else if (currcut.CompareTo("Map") == 0 & currcut.CompareTo(prevcut) != 0){
                inMenu = false;
                inMap = true;
                audioMusic.clip = inGame;
                audioMusic.Play();
            }
            else if (!inMenu & !inMap)
            {
                inMenu = true;
                audioMusic.clip = menu;
                audioMusic.Play();
            }
            else if(inMap & currcut.CompareTo(prevcut) != 0)
            {
                inMap = false;
                inMenu = true;
                audioMusic.clip = menu;
                audioMusic.Play();
            }
            prevScene = current;

        }
    }
}
