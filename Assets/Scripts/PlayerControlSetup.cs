using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlSetup : MonoBehaviour{
    bool animOn;
    bool isRun;
    bool isCrouch;
    bool isJump;
    bool isFall;
    float prevy;

    public float base_speed = 5f;
    public Vector2 base_jumpHeight = new Vector2(0.0f, 8.0f);
    public Animator animator;
    public Quaternion rotator;

    public void Start()
    {
        base_speed *= (Time.deltaTime);
        Invoke("SetAnimator", .5f);
        prevy = gameObject.transform.position.y;
        isCrouch = false;
        animOn = false;
    }

    void SetAnimator()
    {
        animator = gameObject.GetComponentsInChildren<Animator>()[0];
        animOn = true;
    }
    aiwlkdfnkwjadsmn
    void Update()
    {
        if (gameObject.transform.position.y - prevy > 0.05)
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
        isRun = false;
        if (InputManager.MainHorizontal(PlayerControlDelegator.playernum) > 0);
        {
            moveToLeft();
            isRun = true;
        }
        if (InputManager.MainHorizontal(PlayerControlDelegator.playernum) < 0);
        {
            moveToRight();
            isRun = true;
        }
        if(InputManager.Jump(PlayerControlDelegator.playernum))
        {
            playerJump();
        }
        if(InputManager.Power(PlayerControlDelegator.playernum))
        {
            usePowerUp();
        }
        if(InputManager.Croutch(PlayerControlDelegator.playernum))
        {
            useAttack();
            isCrouch = true;
        }
        if (!InputManager.Croutch(PlayerControlDelegator.playernum))
        {
            isCrouch = false;
        }
        if (animOn == true)
        {
            animator.SetBool("isRunning", isRun);
            animator.SetBool("isCrouching", isCrouch);
            animator.SetBool("isJump", isJump);
        }
        prevy = gameObject.transform.position.y;
    }

	virtual public void moveToLeft()
    {
        Vector2 position = this.transform.position;
        position.x -= base_speed;
        this.transform.position = position;
        if (this.transform.rotation.y == 1f)
        {
            rotator = new Quaternion(0f, 0f, 0f, 0f);
            this.transform.rotation = rotator;
        }
    }

    virtual public void moveToRight()
    {
        Vector2 position = this.transform.position;
        position.x += base_speed;
        this.transform.position = position;
        if (this.transform.rotation.y == 0f)
        {
            rotator = new Quaternion(0f, 1f, 0f, 0f);
            this.transform.rotation = rotator;
        }
    }

    virtual public void playerJump()
    {
        GetComponent<Rigidbody2D>().AddForce(base_jumpHeight, ForceMode2D.Impulse);
    }

    virtual public void usePowerUp()
    {
        Debug.Log("A powerup was used.");
    }

    virtual public void useAttack()
    {
        Debug.Log("Attacking...");
    }
}
