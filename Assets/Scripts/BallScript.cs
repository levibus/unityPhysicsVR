using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

/*
* Author: Levi Busching
* Description: Takes care of ball movement and starting position. It contains the functions to launch and reset the ball.
*/

public class BallScript : MonoBehaviour
{
    EventManager eventManager;
    angleEM angleEventManager;
    speedEM speedEventManager;
    heightEM heightEventManager;
    startingPosition startPos;

    public Rigidbody rb;
    
    bool launch = false;                  // true if the ball is launched (and in motion)
    float height = 0.2f;                  // starting values
    float launchAngle = 45.0f;
    float launchSpeed = 500.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   // starts stationary (without gravity)
        rb.useGravity = false;
       
        startPos = new startingPosition(height);        // starting height

        eventManager = FindObjectOfType<EventManager>();
        eventManager.onBallLaunch += LaunchBall;
        eventManager.onBallReset += reset;

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

    void Update()
    {
        startPos.setPosition(height);
        ballStartPosition();
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
        if (height < 5.2f) {
            height++;
        }
    }

    void decreaseHeight() {
        if (height > 1.1f) {
            height--;
        }
    } 

    public void LaunchBall() {
        launch = true;
        rb.useGravity = true;
        float normalizedAngle = launchAngle / 90.0f;            // changes angle from a range of 0-90 to 0-1
        Vector3 angle = new Vector3(0.0f, normalizedAngle, (1.0f - normalizedAngle));
        rb.AddForce(launchSpeed * angle);
    }

    public void reset() {
        launch = false;
        rb.useGravity = false;
        rb.position = startPos.getPosition();
        rb.velocity = Vector3.zero;
    }

    public void ballStartPosition() {
        if (!launch) {
            transform.position = startPos.getPosition();
        }
    }

}