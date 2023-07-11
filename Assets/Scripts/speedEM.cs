using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    void Update() {
        if (Input.GetKeyUp("right")) {
            onSpeedIncrease();
        }
        if (Input.GetKeyUp("left")) {
            onSpeedDecrease();
        }
    }
}
