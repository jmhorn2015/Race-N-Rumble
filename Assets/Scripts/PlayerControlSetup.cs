using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlSetup : MonoBehaviour {
    bool animOn;
    bool isRun;
    bool isCrouch;
    bool isJump;
    bool isFall;
    int PlayerNum;
    float prevy;
    Vector2 offs;
    Vector2 sizer;
    AudioClip audioJump;
    CapsuleCollider2D cc;
    float speedCheck;
    public float base_speed = 5f;
    public Vector2 base_jumpHeight = new Vector2(0.0f, 8.0f);
    public Animator animator;
    public Quaternion rotator;

    public void AddPlayerNum(int x)
    {
        PlayerNum = x;
    }

    //Public void displaypoints(int x){
    // gameobject.addcompontent<text>
    // text.text = points
    //invoke ("destroytext", 2f);
    //}

    //public void destroytext(){
    // remove text component in game object;
    //};

    public void Start()
    {
        base_speed *= Time.deltaTime;
        speedCheck = base_speed;
        Invoke("SetAnimator", .5f);
        prevy = gameObject.transform.position.y;
        isCrouch = false;
        animOn = false;
        cc = gameObject.GetComponent<CapsuleCollider2D>();
        offs = cc.offset;
        sizer = cc.size;
        audioJump = Resources.Load<AudioClip>("Audio/SE/Jump") as AudioClip;
    }

    void SetAnimator()
    {
        animator = gameObject.GetComponentsInChildren<Animator>()[0];
        animOn = true;
    }

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
        if (InputManager.MainHorizontal(PlayerNum) < - .25f)
        {
            moveToLeft();
            isRun = true;
        }
        if (InputManager.MainHorizontal(PlayerNum) > .25f)
        {
            moveToRight();
            isRun = true;
        }
        if(InputManager.Jump(PlayerNum))
        {
            AudioSource.PlayClipAtPoint(audioJump, transform.position);
            playerJump();
        }
        if(InputManager.Power(PlayerNum))
        {
            usePowerUp();
        }
        if(InputManager.Croutch(PlayerNum))
        {
            isCrouch = true;
            base_speed = .5f*speedCheck;
            crouch();
        }
        if (!InputManager.Croutch(PlayerNum))
        {
            isCrouch = false;
            base_speed = speedCheck;
            crouch();
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

    virtual public void crouch()
    {
        if (isCrouch)
        {
            offs.y = -1.068107f;
            sizer.y = 0.833f;
        }
        else
        {
            offs.y = -.4269078f;
            sizer.y = 2.116148f;
        }
        cc.offset = offs;
        cc.size = sizer;
    }
}
