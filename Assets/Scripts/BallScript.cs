using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class BallScript : MonoBehaviour
{

    EventManager eventManager;

    private float force = 1.0f;

    // public event EventHandler<OnBallStartEventArgs> OnBallStart;
    // public class OnBallStartEventArgs : EventArgs {
    //     public Vector3 velocityVector;
    //     public Vector3 positionVector;
    // }

    public Rigidbody rb;
    public Vector3 velocityVector;
    public Vector3 positionVector;
    public Vector3 eulerAngles;
    // public Button resetButton;

    void Start()
    {
        // private InputDeviceCharacterics n_characteristics;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        // velocityVector = new Vector3(0.0f, 0.0f, 0.0f);
        // positionVector = new Vector3(0.0f, 1.5f, 0.0f);
        eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        // resetButton.onClick.AddListener(reset);
        eventManager = FindObjectOfType<EventManager>();
        eventManager.onBallLaunch += LaunchBall;
        eventManager.onBallReset += reset;
    }

    void Update()
    {

        // velocityVector = rb.velocity;
        // positionVector = rb.position; 
        // // eulerAngles = rb.rotation.eulerAngles;

        // OnBallStart?.Invoke(this, new OnBallStartEventArgs {velocityVector = velocityVector, positionVector = positionVector});
        

    }


    public void LaunchBall() {
        rb.useGravity = true;
        rb.AddForce(force * eulerAngles, ForceMode.VelocityChange);
    }

    public void reset() {
        rb.useGravity = false;
        transform.position = new Vector3(0.0f, 1.5f, 0.0f);
    }

}