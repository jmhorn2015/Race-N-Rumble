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
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        isFly = !isFly;
        if (isFly == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
