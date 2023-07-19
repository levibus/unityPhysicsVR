using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class boardAngleEM : MonoBehaviour
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

    void Update() {
        if (Input.GetKeyUp("up")) {
            onAngleIncrease();
        }
        if (Input.GetKeyUp("down")) {
            onAngleDecrease();
        }
    }
}
