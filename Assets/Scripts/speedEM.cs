using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Signals when the buttons are pushed to increase/decrease the launch angle.
*/

public class speedEM : MonoBehaviour
{
    public event Action onSpeedIncrease;
    public event Action onSpeedDecrease;

    void SpeedIncrease() {
        if (onSpeedIncrease != null) {
            onSpeedIncrease();
        }
    }

    void SpeedDecrease() {
       if (onSpeedDecrease != null) {
            onSpeedDecrease();
        }
    }

    void Update() {                                  // can also use keybindings while in the Unity play mode
        if (Input.GetKeyUp("right")) {
            onSpeedIncrease();
        }
        if (Input.GetKeyUp("left")) {
            onSpeedDecrease();
        }
    }
}
