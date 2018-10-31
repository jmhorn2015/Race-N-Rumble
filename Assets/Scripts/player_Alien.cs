using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Alien : PlayerControlSetup {

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
}
