using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class BallScript : MonoBehaviour
{

    EventManager eventManager;
    angleEM arrowEventManager;

    private float force = 500.0f;
    public Vector3 startingPoint = new Vector3(0.0f, 1.5f, 0.0f);

    // public event EventHandler<OnBallStartEventArgs> OnBallStart;
    // public class OnBallStartEventArgs : EventArgs {
    //     public Vector3 velocityVector;
    //     public Vector3 positionVector;
    // }

    public Rigidbody rb;
    public Vector3 velocityVector;
    public Vector3 positionVector;
    public float launchAngle = 45.0f;
    // public Button resetButton;

    void Start()
    {
        // private InputDeviceCharacterics n_characteristics;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
       
        eventManager = FindObjectOfType<EventManager>();
        eventManager.onBallLaunch += LaunchBall;
        eventManager.onBallReset += reset;

        arrowEventManager = FindObjectOfType<angleEM>();
        arrowEventManager.onAngleIncrease += increaseAngle;
        arrowEventManager.onAngleDecrease += decreaseAngle;
    }

    void Update()
    {

        // velocityVector = rb.velocity;
        // positionVector = rb.position; 
        // // eulerAngles = rb.rotation.eulerAngles;

        // OnBallStart?.Invoke(this, new OnBallStartEventArgs {velocityVector = velocityVector, positionVector = positionVector});
        

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

    public void LaunchBall() {
        // transform.eulerAngles = new Vector3(launchAngle, 0.0f, 0.0f);
        // rb.useGravity = true;
        // rb.AddForce(force * transform.up);

        rb.useGravity = true;
        float normalizedAngle = launchAngle / 90.0f;
        Vector3 angle = new Vector3(0.0f, normalizedAngle, (1.0f - normalizedAngle));
        rb.AddForce(force * angle);
    }

    public void reset() {
        rb.useGravity = false;
        transform.position = startingPoint;
        rb.velocity = Vector3.zero;
    }

}