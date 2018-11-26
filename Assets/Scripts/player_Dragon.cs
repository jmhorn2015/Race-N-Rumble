using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Dragon : PlayerControlSetup {
    bool isFly = false;
    override public void playerJump()
    {
        GetComponent<Rigidbody2D>().AddForce(this.base_jumpHeight * 1.2f, ForceMode2D.Impulse);
    }
    public override void usePowerUp()
    {
        if (isPowerUp)
        {

            SaveState.PowerUpLeft[PlayerNum - 1]++;
            animator.SetBool("isFly", !isFly);
            animator.SetBool("isPower", false);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            isFly = !isFly;
            if (isFly)
            {
                Debug.Log(isFly);
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                gameObject.AddComponent<AudioSource>();
                powerActive = Resources.Load<AudioClip>("Audio/Powers/WingFlap_Dragon") as AudioClip;
                gameObject.GetComponent<AudioSource>().clip = powerActive;
            }
            else
            {
                Debug.Log(isFly);
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                Destroy(gameObject.GetComponent<AudioSource>());
            }
        }
    }
}
