using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: Draws the projected launch path of the ball.
*/

public class drawProjection : MonoBehaviour
{
    LineRenderer lineRenderer;

    angleEM angleEventManager;
    speedEM speedEventManager;
    heightEM height1EventManager;
    startingPosition startPos;

    public BallScript ball;

    // these two lines contribute to the length and smoothness of the projected path
    public int numPoints = 100;                         
    public float timeBetweenPoints = 0.05f;

    float launchAngle = 45.0f;                  // starting values
    float launchSpeed1 = 500.0f;
    float height1 = 0.2f;
    int layerMask = 1<<7;          // the collidable layer that will stop the line from being rendered

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        startPos = new startingPosition(height1);   // starting height

        angleEventManager = FindObjectOfType<angleEM>();
        angleEventManager.onAngleIncrease += increaseAngle;
        angleEventManager.onAngleDecrease += decreaseAngle;

        speedEventManager = FindObjectOfType<speedEM>();
        speedEventManager.onSpeedIncrease += increaseSpeed;
        speedEventManager.onSpeedDecrease += decreaseSpeed;

        height1EventManager = FindObjectOfType<heightEM>();
        height1EventManager.onHeightIncrease += increaseHeight1;
        height1EventManager.onHeightDecrease += decreaseHeight1;
    }

    void Update()
    {
        startPos.setPosition(height1);
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = startPos.getPosition();  

        // remaps the angle from 0-90 to 0-1
        float normalizedAngle = launchAngle / 90.0f;
        Vector3 angle = new Vector3(0.0f, normalizedAngle, (1.0f - normalizedAngle));

        Vector3 startingVelocity = angle * (launchSpeed1 / 50.0f);              // scales the velocity

        for (float t = 0.0f; t < numPoints; t += timeBetweenPoints) {           // finds the next point based on the current point and velocity
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t;
            points.Add(newPoint);

            if (Physics.OverlapSphere(newPoint, 1, layerMask).Length > 0) {         // breaks if a certain layer is hit
                lineRenderer.positionCount = points.Count;
                break;
            }

        }
        lineRenderer.SetPositions(points.ToArray());        // draws line
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
        if (launchSpeed1 < 1000.0f) {
            launchSpeed1 += 100.0f;
        }
    }

    void decreaseSpeed() {
        if (launchSpeed1 > 0.0f) {
            launchSpeed1 -= 100.0f;
        }
    } 

    void increaseHeight1() {
        if (height1 < 5.2f) {
            height1 += 1.0f;
        }
    }

    void decreaseHeight1() {
        if (height1 > 0.2f) {
            height1 -= 1.0f;
        }
        if (height1 < 0) {
            height1 = 0.2f;
        }
    } 
}
