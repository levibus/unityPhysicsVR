using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Signals when the buttons are pushed to launch and reset the ball.
*/

public class EventManager : MonoBehaviour
{
    public event Action onBallLaunch;
    public event Action onBallReset;
  
    void BallLaunch() {
        if (onBallLaunch != null) {
            onBallLaunch();
        }
    }

    void BallReset() {
        if (onBallReset != null) {
            onBallReset();
        }
    }

    void Update() {                             // can also use keybindings while in the Unity play mode
        if (Input.GetKeyUp("space")) {
            onBallLaunch();
        }
        if (Input.GetKeyUp("r")) {
            onBallReset();
        }
    }
}
