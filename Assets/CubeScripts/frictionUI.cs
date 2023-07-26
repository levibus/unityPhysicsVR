using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    void Update() {
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
