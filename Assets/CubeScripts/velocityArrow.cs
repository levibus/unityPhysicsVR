using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class velocityArrow : MonoBehaviour
{
    public event Action onArrowDestruction;

    arrowUI arrowEM;
    cubeCollision collision;
    launchEM resetEM;

    public GameObject arrow;
    public GameObject anchor;
    public Rigidbody rb;

    bool active = true;

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onVelocity += arrowOn;

        collision = FindObjectOfType<cubeCollision>();
        collision.onGroundCollision += turnOff;

        resetEM = FindObjectOfType<launchEM>();
        resetEM.onReset += turnOn;

        arrow.SetActive(true);
    }

    void turnOff() {
        arrow.SetActive(false);
    }

    void turnOn() {
        if (active) {
            arrow.SetActive(true);
        }
    }

    void arrowOn() {
        if (!active) {
            arrow.SetActive(true);
            active = true;
            ArrowDestruction();
        }
        else {
            arrow.SetActive(false);
            active = false;
            ArrowDestruction();
        }
    }

    void ArrowDestruction() {
        if (onArrowDestruction != null) {
            onArrowDestruction();
        }
    }
}