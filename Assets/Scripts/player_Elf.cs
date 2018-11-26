using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Writer: Rachel Alexander

public class player_Elf : PlayerControlSetup {
    bool hasInitializedScale = false;
    Vector2 originalScale;
    Vector2 elfScale;
    //the Elf uses her magic to shrink herself to a tiny size, so she can fit through small spaces and gaps in the map

    //by Rachel Alexander
    public override void usePowerUp()
    {
        powerUp = Resources.Load<AudioClip>("Audio/Powers/Shrink01_Elf") as AudioClip;
        base.usePowerUp();
        if (isPowerUp)
        {
            originalScale = gameObject.transform.localScale;
            elfScale = new Vector2(0.2f, 0.2f);
            gameObject.transform.localScale = elfScale;
            Invoke("fixScale", 5f);
        }
    }

    void fixScale()
    {
        this.transform.localScale = originalScale; //reset the character scale
    }
}