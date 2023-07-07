using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
}
