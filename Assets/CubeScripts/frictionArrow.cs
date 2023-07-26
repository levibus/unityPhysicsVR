using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class frictionArrow : MonoBehaviour
{
    public event Action onArrowDestruction;

    arrowUI arrowEM;
    cubeCollision collision;
    launchEM resetEM;

    public GameObject frictionSnap;
    public GameObject arrow;

    float spacing1 = 0.15f;
    bool active = true;

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onFriction += arrowOn;

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

    void Update() {
        if (active && transform.position.x < frictionSnap.transform.position.x + spacing1 && transform.position.y < frictionSnap.transform.position.y + spacing1 && transform.position.z < frictionSnap.transform.position.z + spacing1 && 
            transform.position.x > frictionSnap.transform.position.x - spacing1 && transform.position.y > frictionSnap.transform.position.y - spacing1 && transform.position.z > frictionSnap.transform.position.z - spacing1) {
            active = false;
            arrow.SetActive(false);
            ArrowDestruction();
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