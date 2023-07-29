using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
* Authors: Evan Bourke and Levi Busching
* Description: Changes the direction and scale of the velocity and acceleration arrows on the cube.
*              Currently, the acceleration arrow is commented out, as it is not useful for the demonstration.
*/

public class center : MonoBehaviour
{
    // Class variables

    Rigidbody rb;                     // Rigidbody of the cube
    public GameObject anchor;         // The empty GameObject on the board which signals where the cube starts 
    public GameObject cube;
    public GameObject pivot;
    float normalizedVelAngle = 0.0f;
    float normalizedAccAngle = 0.0f;

    public GameObject velArrowObject; // the empty game object made so that the arrow rotates correctly
    public GameObject accArrowObject; // ditto
    private GameObject arCamera; // this finds the world arCamera to calculate the velocity from it

    public Vector3[] pastPos; // array of the previous positions to allow for smoothing of velocity/acceleration
    public float[] pastTime; // same as above but for time
    private int positionSize = 5; // size of the aforementioned arrays

    public Vector3 currentPos; // the position of the center object relative to the arCamera of this current frame
    public Vector3 currentVel; // the velocity " "
    public Vector3 currentAcc; // the acceleration " "

    public int reportedPrecision = 1; // number of decimal places
    public float lengthScaling = 1000.0f; // the muliplicative scaling of the length of the arrows. The arrows are 1*lengthScaling meters at 1m/s(/s)


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

        accArrowObject.SetActive(false);
        rb = GetComponent<Rigidbody>();

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

    void MoveArrows()
    {

        // move arrow to object center

        velArrowObject.transform.position = transform.position;
        // accArrowObject.transform.position = transform.position;

        //rotate arrows
        if (rb.velocity.y + rb.velocity.z != 0) {
            normalizedVelAngle = 90.0f * rb.velocity.y / (Mathf.Abs(rb.velocity.y) + rb.velocity.z);     // makes the angle into a ratio of 0 - 1 to 0 - 90
        }

        velArrowObject.transform.eulerAngles = new Vector3((90.0f - normalizedVelAngle), 0.0f, 0.0f);             // points the velocity arrow in correct direction

        if (currentAcc.y + currentAcc.z != 0) {
            normalizedAccAngle = 90.0f * currentAcc.y / (Mathf.Abs(currentAcc.y) + Mathf.Abs(currentAcc.z));     // makes the angle into a ratio of 0 - 1 to 0 - 90
        }

        accArrowObject.transform.eulerAngles = new Vector3((90.0f - normalizedAccAngle), 0.0f, 0.0f);
        
        // if acceleration or velocity magnitude is too small, don't display corresponding arrow
        float minSize = Mathf.Pow(10, -reportedPrecision + 1);

        if (currentVel.magnitude <= minSize || cube.transform.position == anchor.transform.position || pivot.transform.eulerAngles.x < 11.0f)
        {
            velArrowObject.SetActive(false);
        }
        else {
            velArrowObject.SetActive(true);
            velArrowObject.transform.localScale = new Vector3(0.25f, lengthScaling * rb.velocity.magnitude, 0.25f);
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
