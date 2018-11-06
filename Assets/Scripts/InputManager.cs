using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InputManager   // Does not inherit monobehavior since the input can be used and given anywhere from the code structure
{
    

    public static float MainHorizontal(int x)
    {
        float r = 0.0f;
        r += Input.GetAxis("Xbox_MainHorizontal" + x); //Xbox 360 Controls
        r += Input.GetAxis("K_MainHorizontal" + x);
        return r;
    }

    public static bool Jump(int x)
    {
        bool a = Input.GetButtonDown("Xbox_Jump" + x); //Xbox 360 Controls
        bool c = Input.GetButtonDown("K_Jump" + x);
        return a | c;
    }

    public static bool Croutch(int x)
    {
        bool a = Input.GetButton("Xbox_Croutch" + x); //Xbox 360 Controls
        bool c = Input.GetButton("K_Croutch" + x);
        return a | c;
    }

    public static bool Power(int x)
    {
        bool a = Input.GetButtonDown("Xbox_Power" + x); //Xbox 360 Controls
        bool c = Input.GetButtonDown("K_Power" + x);
        return a | c;
    }


}
