using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Alien : PlayerControlSetup {
    GameObject[] PlayerArray;
    bool CoolDown = false;

	override public void moveToLeft()
    {
        Vector2 position = this.transform.position;
        position.x += base_speed*2f;
        this.transform.position = position;
        if (this.transform.rotation.y == 1f)
        {
            rotator = new Quaternion(0f, 0f, 0f, 0f);
            this.transform.rotation = rotator;
        }
    }

    public override void moveToRight()
    {
        Vector2 position = this.transform.position;
        position.x -= base_speed * 2f;
        this.transform.position = position;
        if (this.transform.rotation.y == 0f)
        {
            rotator = new Quaternion(0f, 1f, 0f, 0f);
            this.transform.rotation = rotator;
        }
    }

    public override void playerJump()
    {
        GetComponent<Rigidbody2D>().AddForce(base_jumpHeight * 1.1f, ForceMode2D.Impulse);
    }

    public override void usePowerUp()
    {
        powerUp = Resources.Load<AudioClip>("Audio/Powers/Shrink02_Elf") as AudioClip;
        base.usePowerUp(); 
        if (isPowerUp)
        {
            speedCheck /= 2f;
            PlayerArray = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject x in PlayerArray)
            {
                if (x.name.CompareTo(gameObject.name) != 0)
                {
                    x.GetComponent<PlayerControlSetup>().enabled = false;
                    Rigidbody2D z = x.GetComponent<Rigidbody2D>();
                    z.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
            Invoke("ReleasePlayers", 5f);
        }
    }
    public void ReleasePlayers()
    {
        Debug.Log("release");
        speedCheck = orig_speed*2f;
        foreach (GameObject x in PlayerArray)
        {
            if (x.name.CompareTo(gameObject.name) != 0)
            {
                x.GetComponent<PlayerControlSetup>().enabled = true;
                Rigidbody2D z = x.GetComponent<Rigidbody2D>();
                z.constraints = RigidbodyConstraints2D.None;
                z.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
