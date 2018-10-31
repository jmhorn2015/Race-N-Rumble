using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Dragon : PlayerControlSetup {
    bool isFly;
    override public void playerJump()
    {
        GetComponent<Rigidbody2D>().AddForce(this.base_jumpHeight * 1.2f, ForceMode2D.Impulse);
    }
    public override void usePowerUp()
    {
        isFly = !isFly;
    }
}
