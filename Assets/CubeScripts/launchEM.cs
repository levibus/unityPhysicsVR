using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Signals when the "Launch" and "reset" buttons are pressed in the UI to launch the cube or return it to its starting position.
*/

public class launchEM : MonoBehaviour
{
    public event Action onLaunch;
    public event Action onReset;
  
    void Launch() {
        if (onLaunch != null) {
            onLaunch();
        }
    }

    void Reset() {
        if (onReset != null) {
            onReset();
        }
    }

    void Update() {                         // can also use keybindings while in the Unity play mode
        if (Input.GetKeyUp("space")) {
            onLaunch();
        }
        if (Input.GetKeyUp("r")) {
            onReset();
        }
    }
}