using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Signals when the buttons are pushed to turn the arrows on/off.
*/

public class arrowUI : MonoBehaviour
{

    public event Action onVelocity;
    public event Action onNormal;
    public event Action onXGravity;
    public event Action onYGravity;
    public event Action onFriction;
  
    void Velocity() {
        if (onVelocity != null) {
            onVelocity();
        }
    }

    void Normal() {
        if (onNormal != null) {
            onNormal();
        }
    }

    void XGravity() {
        if (onXGravity != null) {
            onXGravity();
        }
    }

    void YGravity() {
        if (onYGravity != null) {
            onYGravity();
        }
    }

    void Friction() {
        if (onFriction != null) {
            onFriction();
        }
    }

    void Update() {                         // can also use keybindings while in the Unity play mode
        if (Input.GetKeyUp("v")) {
            onVelocity();
        }
        if (Input.GetKeyUp("n")) {
            onNormal();
        }
        if (Input.GetKeyUp("x")) {
            onXGravity();
        }
        if (Input.GetKeyUp("y")) {
            onYGravity();
        }
        if (Input.GetKeyUp("f")) {
            onFriction();
        }
    }
}