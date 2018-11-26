using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButtonText : MonoBehaviour {
    public bool mapOrAudio;
    AudioSource music;
	void Start () {
        music = GameObject.Find("Background Music").GetComponent<AudioSource>();
        Text displayer = this.GetComponentsInChildren<Text>()[0];
        if (mapOrAudio)
        {
            displayer.text = "# of Maps: " + StartGame.MapMax.ToString();
        }
        else if(!mapOrAudio & music.volume == .1f)
        {
            displayer.text = "Music: On";
        }
        else
        {
            displayer.text = "Music: Off";
        }
    }

}
