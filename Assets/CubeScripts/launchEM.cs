using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    void Update() {
        if (Input.GetKeyUp("space")) {
            onLaunch();
        }
        if (Input.GetKeyUp("r")) {
            onReset();
        }
    }
}