using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
* Authors: Evan Bourke and Levi Busching
* Description: Modifies the velocity and acceleration arrows inflight and before the launch. Calculates the velocity and acceleration 
*              to change the position, orientation, and scaling of the arrows, as well as changes their activity status.
*/

public class ObjectCenter : MonoBehaviour
{
    // Class variables

    EventManager launchEventManager;
    angleEM angleEventManager;
    speedEM speedEventManager;
    heightEM heightEventManager;
    startingPosition startPos;  // a class that can get and set the starting position... used for changing the height of the launch

    public Rigidbody rb; 
    float normalizedVelAngle = 0.0f;           // used to normalized angles
    float normalizedAccAngle = 0.0f;
    float scaleDown = 0.25f;                   // scales the arrows 
    float normalizedSpeed = 2.0f;              // starting value for a scaled-down speed
    float height = 0.2f;                       // starting height
    bool launch = false;                       // true if ball as launched (and is in motion)

    public GameObject velArrowObject; // the empty game object made so that the arrow rotates correctly
    public GameObject accArrowObject; // ditto
    // public GameObject velArrow; // starts as a prefab, then is instantiated and reassigned to the actual created object
    // public GameObject accArrow; // ditto
    private GameObject arCamera; // this finds the world arCamera to calculate the velocity from it
    public float launchAngle = 45.0f; // this is the starting launch angle of the ball (45 degrees)
    public float launchSpeed1 = 500.0f; // I may modify this to be a user-input value if I have the time TODO

    public Vector3[] pastPos; // array of the previous positions to allow for smoothing of velocity/acceleration
    public float[] pastTime; // same as above but for time
    private int positionSize = 5; // size of the aforementioned arrays

    public Vector3 currentPos; // the position of the center object relative to the arCamera of this current frame
    public Vector3 currentVel; // the velocity " "
    public Vector3 currentAcc; // the acceleration " "

    // private ArrowContainer VArrowContainer; // this is just the object assigned to the arrow for easier management of the pieces
    // private ArrowContainer AArrowContainer; // ditto

    public int reportedPrecision = 2; // number of decimal places
    public float lengthScaling = 1f; // the muliplicative scaling of the length of the arrows. The arrows are 1*lengthScaling meters at 1m/s(/s)


    // --FOR TESTING--
    // intrinsic motion of object center from Unity

    public Vector3 testVel = new Vector3(0, 0, 0); 
    public Vector3 testAcc = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.Find("AR Camera"); // find and assign the camera for calculations
        if (arCamera == null)
        {
            arCamera = GameObject.Find("CenterEyeAnchor");
        }

        startPos = new startingPosition(height);
        rb = GetComponent<Rigidbody>();

        launchEventManager = FindObjectOfType<EventManager>();
        launchEventManager.onBallLaunch += accActive;
        launchEventManager.onBallReset += accInactive;

        angleEventManager = FindObjectOfType<angleEM>();
        angleEventManager.onAngleIncrease += increaseAngle;
        angleEventManager.onAngleDecrease += decreaseAngle;

        speedEventManager = FindObjectOfType<speedEM>();
        speedEventManager.onSpeedIncrease += increaseSpeed;
        speedEventManager.onSpeedDecrease += decreaseSpeed;

        heightEventManager = FindObjectOfType<heightEM>();
        heightEventManager.onHeightIncrease += increaseHeight;
        heightEventManager.onHeightDecrease += decreaseHeight;

        // setup for position and time
        pastPos = new Vector3[positionSize];
        pastTime = new float[positionSize];

        // initialization to avoid errors
        for (int i = 0; i < positionSize; i++)
        {
            pastPos[i] = transform.position - arCamera.transform.position;
            pastTime[i] = 1;
        }

        //priming
        currentVel = Vector3.zero;
        currentAcc = Vector3.zero;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        startPos.setPosition(height);
        // intrinsic motion for testing
        float delTime = Time.deltaTime;
        testVel += testAcc * delTime;
        transform.Translate(testVel * delTime);

        // the actual loop
        SetVelAcc(); // find position, velocity, and acceleration
        MoveArrows(); // change the arrows based on the values
    }


    void SetVelAcc()
    {
        // set variables
        Vector3 tempPos;
        Vector3 tempVel;
        Vector3 tempAcc;

        // start calculations
        tempPos = transform.position - arCamera.transform.position; // reported from the ar camera

        pushPos(tempPos);
        pushTime(Time.deltaTime);

        //find velocity/acceleration of object
        Vector3[] holdArr = findVelAcc();
        tempVel = holdArr[0];
        tempAcc = holdArr[1];

        // round to specified number of decimal places
        float tenOrder = Mathf.Pow(10, reportedPrecision);
        float tenthOrder = Mathf.Pow(10, -reportedPrecision);

        tempVel = new Vector3(Mathf.Round(tenOrder * tempVel.x) * tenthOrder,
            Mathf.Round(tenOrder * tempVel.y) * tenthOrder, Mathf.Round(tenOrder * tempVel.z) * tenthOrder);

        tempAcc = new Vector3(Mathf.Round(tenOrder * tempAcc.x) * tenthOrder,
            Mathf.Round(tenOrder * tempAcc.y) * tenthOrder, Mathf.Round(tenOrder * tempAcc.z) * tenthOrder);


        // set p,v,a for this frame
        currentPos = tempPos;
        currentVel = tempVel;
        currentAcc = tempAcc;
    }

    void accActive() {
        launch = true;
    }

    void accInactive() {
        launch = false;
    }

    void increaseAngle() {
        if (launchAngle > 0.0f) {
            launchAngle -= 5.0f;
        }
    }

    void decreaseAngle() {
        if (launchAngle < 90.0f) {
            launchAngle += 5.0f;
        }
    }

    void increaseSpeed() {
        if (launchSpeed1 < 1000.0f) {
            launchSpeed1 += 100.0f;
        }
    }

    void decreaseSpeed() {
        if (launchSpeed1 > 0.0f) {
            launchSpeed1 -= 100.0f;
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

    void MoveArrows()
    {

        // move arrows to object center

        velArrowObject.transform.position = transform.position;
        accArrowObject.transform.position = transform.position;

        //rotate arrows

        
        if (rb.velocity.y + rb.velocity.z != 0) {
            normalizedVelAngle = 90.0f * rb.velocity.y / (Mathf.Abs(rb.velocity.y) + rb.velocity.z);              // makes the angle into a ratio of 0-1 to 0-90
        }
        velArrowObject.transform.eulerAngles = new Vector3((90.0f - normalizedVelAngle), 0.0f, 0.0f);             // points the velocity arrow in correct direction

        if (currentAcc.y + currentAcc.z != 0) {
            normalizedAccAngle = 90.0f * currentAcc.y / (Mathf.Abs(currentAcc.y) + Mathf.Abs(currentAcc.z));      // makes the angle into a ratio of 0-1 to 0-90
        }
        accArrowObject.transform.eulerAngles = new Vector3((90.0f - normalizedAccAngle), 0.0f, 0.0f);             // points the acceleration arrow in correct direction

        // if acceleration or velocity magnitude is too small, don't display corresponding arrow
        float minSize = Mathf.Pow(10, -reportedPrecision + 1) + 0.5f;                                 

        if (transform.position == startPos.getPosition()) {
            velArrowObject.SetActive(true);
            normalizedSpeed = launchSpeed1 / 200.0f;                                                         // scales the speed because launching works well but the arrow is too long
            velArrowObject.transform.localScale = new Vector3(1f, normalizedSpeed, 1f) * scaleDown;          // using a scaling factor
            velArrowObject.transform.eulerAngles = new Vector3(launchAngle, 0.0f, 0.0f);
        }
        if (currentVel.magnitude <= minSize && transform.position != startPos.getPosition())
        {
            velArrowObject.SetActive(false);
        }
        else if (transform.position != startPos.getPosition()) {
            velArrowObject.SetActive(true);
            velArrowObject.transform.localScale = new Vector3(1f, lengthScaling * rb.velocity.magnitude, 1f) * scaleDown;   // scales velocity arrow
        }

        if (currentAcc.magnitude <= minSize || !launch)
        {
            accArrowObject.SetActive(false);
        }
        else
        {
            accArrowObject.SetActive(true);
            accArrowObject.transform.localScale = new Vector3(1f, lengthScaling * currentAcc.magnitude * 0.5f, 1f) * scaleDown;    // scales accleration arrow
        }
    }


    // Position array handling, upgraded velocity and acceleration
    // The structure is that pastPos[0] is the most recent and pastPos[positionSize-1] is the oldest, same with pastTime

    // add the next position to pastPos[0] and move all of the elements down the line
    void pushPos(Vector3 nextPosition) 
    {
        for (int i = positionSize - 1; i > 0; i--)
        {
            pastPos[i] = pastPos[i - 1];
        }

        pastPos[0] = nextPosition;
    }

    void pushTime (float nextTime)
    {
        for (int i = positionSize - 1; i > 0; i--)
        {
            pastTime[i] = pastTime[i - 1];
        }

        pastTime[0] = nextTime;
    }


    Vector3[] findVelAcc()
    {
        Vector3 vel = new Vector3(0, 0, 0);
        Vector3 acc = new Vector3(0, 0, 0);
        float accChangeRate = 0.1f;

        //vel = (.5f * (pastPos[0] - pastPos[1]) / pastTime[0] + .25f * (pastPos[1] - pastPos[2]) / pastTime[1] + .25f * (pastPos[2] - pastPos[3]) / pastTime[2]);
        vel = rb.velocity;
        acc = (.5f * ((pastPos[0] - pastPos[1]) / pastTime[0] - (pastPos[1] - pastPos[2]) / pastTime[1]) / pastTime[0]
            + .25f * ((pastPos[1] - pastPos[2]) / pastTime[1] - (pastPos[2] - pastPos[3]) / pastTime[2]) / pastTime[1]
            + .125f * ((pastPos[2] - pastPos[3]) / pastTime[2] - (pastPos[3] - pastPos[4]) / pastTime[3]) / pastTime[2]);
        acc = (accChangeRate * acc + (1f - accChangeRate) * currentAcc);

        Vector3[] returnArr = new Vector3[2];
        returnArr[0] = vel;
        returnArr[1] = acc;
        return returnArr;
    }
}
