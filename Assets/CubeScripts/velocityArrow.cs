using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Toggles the visibility (activity) of the velocity arrow. This arrow will become inactive when the cube hits the ground.
*              Along with the rest of the arrows, it can be turned on and off by touching the velocitySnap UI button.
*/

public class velocityArrow : MonoBehaviour
{
    public event Action onArrowDestruction;

    arrowUI arrowEM;
    cubeCollision collision;
    launchEM resetEM;

    public GameObject arrow;
    public GameObject anchor;
    public Rigidbody rb;               // cube Rigidbody

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

    void turnOff() {                   // turned off when the cube hits the ground
        arrow.SetActive(false);
    }

    void turnOn() {                    // turned on when the cube is reset (if arrow is active)
        if (active) {
            arrow.SetActive(true);
        }
    }

    void arrowOn() {                   // toggles if the arrow is active
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

    void ArrowDestruction() {        // event that toggles when the arrow activity status is changed
        if (onArrowDestruction != null) {
            onArrowDestruction();
        }
    }
}