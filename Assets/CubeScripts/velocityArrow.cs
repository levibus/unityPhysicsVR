using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityArrow : MonoBehaviour
{
    public GameObject arrow;
    arrowUI arrowEM;
    cubeCollision collision;
    launchEM resetEM;
    bool test = true;

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onVelocity += changeActive;

        collision = FindObjectOfType<cubeCollision>();
        collision.onGroundCollision += turnOff;

        resetEM = FindObjectOfType<launchEM>();
        resetEM.onReset += turnOn;
    }

    void changeActive() {
        if (!test) {
            arrow.SetActive(true);
            test = true;
        }
        else {
            arrow.SetActive(false);
            test = false;

        }
    }

    void turnOff() {
        arrow.SetActive(false);
    }

    void turnOn() {
        if (test) {
            arrow.SetActive(true);
        }
    }
}