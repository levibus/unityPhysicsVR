using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    void Update() {
        if (Input.GetKeyUp("w")) {
            onHeightIncrease();
        }
        if (Input.GetKeyUp("s")) {
            onHeightDecrease();
        }
    }
}