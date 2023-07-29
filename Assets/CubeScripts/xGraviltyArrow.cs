using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Toggles the visibility (activity) of the xGravity arrow. This arrow will become inactive when the cube hits the ground.
*              Along with the rest of the arrows, it can be turned on and off by touching the xGravitySnap UI button, or can be 
*              turned off by holding it close to the xGravitySnap box.
*/

public class xGravityArrow : MonoBehaviour
{
    public event Action onArrowDestruction;

    arrowUI arrowEM;
    cubeCollision collision;
    launchEM resetEM;

    public GameObject xGravSnap;    // the colored box related to the xGravity arrow UI
    public GameObject arrow;

    float spacing1 = 0.15f;         // the spacing away from the center of the xGravitySnap box in every direction
    bool active = true;             // if the arrow is active 

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onXGravity += arrowOn;

        collision = FindObjectOfType<cubeCollision>();
        collision.onGroundCollision += turnOff;

        resetEM = FindObjectOfType<launchEM>();
        resetEM.onReset += turnOn;

        arrow.SetActive(true);     // starts out as active
    }

    void turnOff() {               // turned off when the cube hits the ground
        arrow.SetActive(false);
    }

    void turnOn() {                // turned on when cube is reset (if arrow is active)
        if (active) {
            arrow.SetActive(true);
        }
    }


    void Update() {
        // checks if the arrow is active and "spacing1" away from the center of the xGravitySnap box in every direction
        if (active && transform.position.x < xGravSnap.transform.position.x + spacing1 && transform.position.y < xGravSnap.transform.position.y + spacing1 && transform.position.z < xGravSnap.transform.position.z + spacing1 && 
            transform.position.x > xGravSnap.transform.position.x - spacing1 && transform.position.y > xGravSnap.transform.position.y - spacing1 && transform.position.z > xGravSnap.transform.position.z - spacing1) {
            active = false;
            arrow.SetActive(false);
            ArrowDestruction();
        }
    }

    void arrowOn() {            // toggles if the arrow is active or not
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

    void ArrowDestruction() {          // event that toggles when the arrow activity status is changed
        if (onArrowDestruction != null) {
            onArrowDestruction();
        }
    }
}