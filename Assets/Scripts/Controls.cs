using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Writer: Rachel Alexander

public class Controls : MonoBehaviour
{
    public int PlayNum;

    private enum Character { Dragon, Alien, Normal1, Normal2 };

    private Character myCharacter = Character.Normal1;

    private float base_speed = 0.1f;
    private Vector2 base_jumpHeight = new Vector2(0.0f, 8.0f);

    bool isMovingLeft_Dragon = false;
    bool isMovingRight_Dragon = false;
    bool isMovingLeft_Alien = false;
    bool isMovingRight_Alien = false;
    bool isMovingLeft_Normal1 = false;
    bool isMovingRight_Normal1 = false;
    bool isMovingLeft_Normal2 = false;
    bool isMovingRight_Normal2 = false;

    void Start() //Edited by Jenna Horn
    {
        string type = SaveState.Players[PlayNum-1].Attack;
        if (type.CompareTo("Dragon") == 0)
        {
            myCharacter = Character.Dragon;
        }
        else if (type.CompareTo("Alien") == 0)
        {
            myCharacter = Character.Alien;
        }
        else if (type.CompareTo("Normal1") == 0)
        {
            myCharacter = Character.Normal1;
        }
        else if (type.CompareTo("Normal2") == 0)
        {
            myCharacter = Character.Normal2;
        }
        else
        {
            Debug.Log(type);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (myCharacter == Character.Dragon)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isMovingLeft_Dragon = true;
                isMovingRight_Dragon = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isMovingLeft_Dragon = false;
                isMovingRight_Dragon = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                isMovingLeft_Dragon = false;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                isMovingRight_Dragon = false;
            }

            if (isMovingLeft_Dragon)
            {
                Vector2 position = this.transform.position;
                position.x -= base_speed;
                this.transform.position = position;
            }
            if (isMovingRight_Dragon)
            {
                Vector2 position = this.transform.position;
                position.x += base_speed;
                this.transform.position = position;
            }

            //gliding

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(base_jumpHeight * 0.8f, ForceMode2D.Impulse);
            }
        }

        if (myCharacter == Character.Alien)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                isMovingLeft_Alien = true;
                isMovingRight_Alien = false;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                isMovingLeft_Alien = false;
                isMovingRight_Alien = true;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                isMovingLeft_Alien = false;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                isMovingRight_Alien = false;
            }

            if (isMovingLeft_Alien)
            {
                Vector2 position = this.transform.position;
                position.x -= base_speed * 1.25f;
                this.transform.position = position;
            }
            if (isMovingRight_Alien)
            {
                Vector2 position = this.transform.position;
                position.x += base_speed * 1.25f;
                this.transform.position = position;
            }

            //jumping
            if (Input.GetKeyDown(KeyCode.W))
            {
                GetComponent<Rigidbody2D>().AddForce(base_jumpHeight * 1.2f, ForceMode2D.Impulse);
            }

        }

        if (myCharacter == Character.Normal1)
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                isMovingLeft_Normal1 = true;
                isMovingRight_Normal1 = false;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                isMovingLeft_Normal1 = false;
                isMovingRight_Normal1 = true;
            }
            if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                isMovingLeft_Normal1 = false;
            }
            if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                isMovingRight_Normal1 = false;
            }

            if (isMovingLeft_Normal1)
            {
                Vector2 position = this.transform.position;
                position.x -= base_speed;
                this.transform.position = position;
            }
            if (isMovingRight_Normal1)
            {
                Vector2 position = this.transform.position;
                position.x += base_speed;
                this.transform.position = position;
            }

            //jumping
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                GetComponent<Rigidbody2D>().AddForce(base_jumpHeight, ForceMode2D.Impulse);
            }
        }
        if (myCharacter == Character.Normal2) //Edited by Jenna Horn
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isMovingLeft_Normal2 = true;
                isMovingRight_Normal2 = false;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                isMovingLeft_Normal2 = false;
                isMovingRight_Normal2 = true;
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                isMovingLeft_Normal2 = false;
            }
            if (Input.GetKeyUp(KeyCode.H))
            {
                isMovingRight_Normal2 = false;
            }

            if (isMovingLeft_Normal2)
            {
                Vector2 position = this.transform.position;
                position.x -= base_speed;
                this.transform.position = position;
            }
            if (isMovingRight_Normal2)
            {
                Vector2 position = this.transform.position;
                position.x += base_speed;
                this.transform.position = position;
            }

            //jumping
            if (Input.GetKeyDown(KeyCode.T))
            {
                GetComponent<Rigidbody2D>().AddForce(base_jumpHeight, ForceMode2D.Impulse);
            }
        }

    }

}
