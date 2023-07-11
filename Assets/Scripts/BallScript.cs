using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class BallScript : MonoBehaviour
{

    EventManager eventManager;
    angleEM angleEventManager;
    speedEM speedEventManager;
    heightEM heightEventManager;
    startingPosition startPos;

    public int test = 0;
    public float height = 0.2f;

    public Rigidbody rb;
    public Vector3 velocityVector;
    public Vector3 positionVector;
    public float launchAngle = 45.0f;
    public float launchSpeed = 500.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
       
        startPos = new startingPosition(height);

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
        if (height > 0.2f) {
            height--;
        }
    } 

    public void LaunchBall() {
        test = 1;
        rb.useGravity = true;
        float normalizedAngle = launchAngle / 90.0f;
        Vector3 angle = new Vector3(0.0f, normalizedAngle, (1.0f - normalizedAngle));
        rb.AddForce(launchSpeed * angle);
    }

    public void reset() {
        test = 0;
        rb.useGravity = false;
        rb.position = startPos.getPosition();
        rb.velocity = Vector3.zero;
    }

    public void ballStartPosition() {
        if (test == 0) {
            transform.position = startPos.getPosition();
        }
    }

}