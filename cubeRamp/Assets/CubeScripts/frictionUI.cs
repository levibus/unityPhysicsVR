using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Signals when the UI buttons are pressed to increase/decrease the dynamic or static coefficient of friction on the cube.
*/

public class frictionUI : MonoBehaviour
{
    public event Action onDynoFrictionIncrease;
    public event Action onDynoFrictionDecrease;

    public event Action onStaticFrictionIncrease;
    public event Action onStaticFrictionDecrease;

    void DynoFrictionIncrease() {
        if (onDynoFrictionIncrease != null) {
            onDynoFrictionIncrease();
        }
    }

    void DynoFrictionDecrease() {
        if (onDynoFrictionDecrease != null) {
            onDynoFrictionDecrease();
        }
    }

    void StaticFrictionIncrease() {
        if (onStaticFrictionIncrease != null) {
            onStaticFrictionIncrease();
        }
    }

    void StaticFrictionDecrease() {
        if (onStaticFrictionDecrease != null) {
            onStaticFrictionDecrease();
        }
    }

    void Update() {                       // can also use keybindings while in the Unity play mode
        if (Input.GetKeyUp("p")) {
            onDynoFrictionIncrease();
        }
        if (Input.GetKeyUp("o")) {
            onDynoFrictionDecrease();
        }

        if (Input.GetKeyUp("l")) {
            onStaticFrictionIncrease();
        }
        if (Input.GetKeyUp("k")) {
            onStaticFrictionDecrease();
        }
    }
}
