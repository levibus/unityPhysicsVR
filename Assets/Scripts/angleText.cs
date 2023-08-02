using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
* Author: Levi Busching
* Description: Creates the text UI for the launch height, launch force, and launch angle of the ball.
*/
 
public class angleText : MonoBehaviour
{
    angleEM angleEventManager;
    speedEM speedEventManager;
    heightEM heightEventManager;

    public TMP_Text label;                      // the text GameObject
    public float launchAngle = 45.0f;           // starting values
    public float launchSpeed = 500.0f;          
    public float height = 0.0f;                 
 
    private void Start()
    {
        label.text = "Angle: " + launchAngle + "\u00B0" + "\n" + "Force: " + (launchSpeed / 10f) + "N" + "\n" +
                    "Height: " + (height) + "m";          // starting values

        angleEventManager = FindObjectOfType<angleEM>();
        angleEventManager.onAngleIncrease += increaseAngle;
        angleEventManager.onAngleDecrease += decreaseAngle;

        speedEventManager = FindObjectOfType<speedEM>();
        speedEventManager.onSpeedIncrease += increaseSpeed;
        speedEventManager.onSpeedDecrease += decreaseSpeed;

        heightEventManager = FindObjectOfType<heightEM>();
        heightEventManager.onHeightIncrease += increaseHeight;
        heightEventManager.onHeightDecrease += decreaseHeight;
    }

    private void Update() {
        label.text = "Angle: " + launchAngle + "\u00B0" + "\n" + "Force: " + (launchSpeed / 10f) + "N" + "\n" +
                    "Height: " + height + "m";          // updated values, launchSpeed is scaled to make it more appropriate
    }

    void increaseAngle() {
        if (launchAngle < 90.0f) {
            launchAngle += 5.0f;
        }
    }

    void decreaseAngle() {
        if (launchAngle > 0.0f) {
            launchAngle -= 5.0f;
        }
    } 

    void increaseSpeed() {
        if (launchSpeed < 1000.0f) {
            launchSpeed += 100.0f;
        }
    }

    void decreaseSpeed() {
        if (launchSpeed > 0.0f) {
            launchSpeed -= 100.0f;
        }
    } 

    void increaseHeight() {
        if (height < 5.0f) {
            height += 1.0f;
        }
    }

    void decreaseHeight() {
        if (height > 1.0f) {
            height -= 1.0f;
        }
    } 
}