using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Signals when the buttons are pushed to increase/decrease the height of the ball.
*/

public class heightEM : MonoBehaviour
{

    public event Action onHeightIncrease;
    public event Action onHeightDecrease;

    void HeightIncrease() {
        if (onHeightIncrease != null) {
            onHeightIncrease();
        }
    }

    void HeightDecrease() {
       if (onHeightDecrease != null) {
            onHeightDecrease();
        }
    }

    void Update() {                                   // can also use keybindings while in the Unity play mode
        if (Input.GetKeyUp("w")) {
            onHeightIncrease();
        }
        if (Input.GetKeyUp("s")) {
            onHeightDecrease();
        }
    }
}