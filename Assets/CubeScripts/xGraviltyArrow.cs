using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class xGravityArrow : MonoBehaviour
{
    public event Action onArrowDestruction;

    arrowUI arrowEM;
    cubeCollision collision;
    launchEM resetEM;

    public GameObject xGravSnap;
    public GameObject arrow;

    float spacing1 = 0.5f;
    bool active = true;

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onXGravity += arrowOn;

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
        if (active && transform.position.x < xGravSnap.transform.position.x + spacing1 && transform.position.y < xGravSnap.transform.position.y + spacing1 && transform.position.z < xGravSnap.transform.position.z + spacing1 && 
            transform.position.x > xGravSnap.transform.position.x - spacing1 && transform.position.y > xGravSnap.transform.position.y - spacing1 && transform.position.z > xGravSnap.transform.position.z - spacing1) {
            active = false;
            arrow.SetActive(false);
            ArrowDestruction();
        }
    }

    void arrowOn() {
        arrow.SetActive(true);
        active = true;
    }

    void ArrowDestruction() {
        if (onArrowDestruction != null) {
            onArrowDestruction();
        }
    }
}