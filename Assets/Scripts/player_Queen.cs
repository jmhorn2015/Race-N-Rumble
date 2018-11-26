using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Queen: PlayerControlSetup {
    //add implementation for attacks and powerups latahhh
    bool MusicOff;
    public override void usePowerUp()
    {
        base.usePowerUp();
        if (isPowerUp)
        {
            AudioSource music = GameObject.Find("Background Music").GetComponent<AudioSource>();
            if (music.volume > 0)
            {
                music.volume = 0;
                Invoke("MusicOn", 5f);
            }
            int numToPlay = Random.Range(1, 4);
            AudioClip meme = Resources.Load<AudioClip>("Audio/Powers/Meme" + numToPlay.ToString());
            AudioSource.PlayClipAtPoint(meme, new Vector2(0f, 0f));
        }
    }
    void MusicOn()
    {
        AudioSource music = GameObject.Find("Background Music").GetComponent<AudioSource>();
        music.volume = .1f;
    }
}
