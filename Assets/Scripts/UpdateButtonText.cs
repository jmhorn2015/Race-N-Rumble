using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButtonText : MonoBehaviour {
    public bool isMap;
    public bool isAudio;
    public bool isPlayer;
    AudioSource music;
	void Start () {
        music = GameObject.Find("Background Music").GetComponent<AudioSource>();
        Text displayer = this.GetComponentsInChildren<Text>()[0];
        if (isMap)
        {
            displayer.text = "# of Maps: " + StartGame.MapMax.ToString();
        }
        else if(isAudio & music.volume == .1f)
        {
            displayer.text = "Music: On";
        }
        else if(isAudio)
        {
            displayer.text = "Music: Off";
        }
        else if (isPlayer)
        {
            displayer.text = SaveState.howManyPlayers.ToString() + " Plyrs";
        }
    }

}
