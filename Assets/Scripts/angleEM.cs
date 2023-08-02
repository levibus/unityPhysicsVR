using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Signals when the buttons are pushed to increase/decrease the launch angle.
*/

public class angleEM : MonoBehaviour
{
    public event Action onAngleIncrease;
    public event Action onAngleDecrease;

    void AngleIncrease() {
        if (onAngleIncrease != null) {
            onAngleIncrease();
        }
    }

    void AngleDecrease() {
       if (onAngleDecrease != null) {
            onAngleDecrease();
        }
    }

    void Update() {                              // can also use keybindings while in the Unity play mode
        if (Input.GetKeyUp("up")) {
            onAngleIncrease();
        }
        if (Input.GetKeyUp("down")) {
            onAngleDecrease();
        }
    }
}
