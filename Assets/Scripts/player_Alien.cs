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
        PlayerArray = GameObject.FindGameObjectsWithTag("Player");
        if (!CoolDown)
        {
            foreach (GameObject x in PlayerArray)
            {
                if (x.name.CompareTo(gameObject.name) == 1)
                {
                    PlayerControlSetup y = x.GetComponent<PlayerControlSetup>();
                    y.enabled = !y.enabled;
                    Rigidbody2D z = x.GetComponent<Rigidbody2D>();
                    z.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
            }
            CoolDown = true;
            Invoke("ReleasePlayers", 3f * (1-Time.deltaTime));
        }
    }
    public void ReleasePlayers()
    {
        Debug.Log("release");
        foreach (GameObject x in PlayerArray)
        {
            if (x.name.CompareTo(gameObject.name) == 1)
            {
                PlayerControlSetup y = x.GetComponent<PlayerControlSetup>();
                y.enabled = !y.enabled;
                Rigidbody2D z = x.GetComponent<Rigidbody2D>();
                z.constraints = RigidbodyConstraints2D.None;
                z.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        Invoke("ResetCoolDown", 15f * (1-Time.deltaTime));
    }
    public void ResetCoolDown()
    {
        CoolDown = false;
    }
}
