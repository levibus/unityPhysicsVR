using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    void Update() {
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