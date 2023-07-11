using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawProjection : MonoBehaviour
{
    LineRenderer lineRenderer;

    angleEM angleEventManager;
    speedEM speedEventManager;

    public int numPoints = 25;
    public float timeBetweenPoints = 0.04f;

    public float launchAngle = 45.0f;
    public float launchSpeed1 = 500.0f;

    public LayerMask CollidableLayers;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        angleEventManager = FindObjectOfType<angleEM>();
        angleEventManager.onAngleIncrease += increaseAngle;
        angleEventManager.onAngleDecrease += decreaseAngle;

        speedEventManager = FindObjectOfType<speedEM>();
        speedEventManager.onSpeedIncrease += increaseSpeed;
        speedEventManager.onSpeedDecrease += decreaseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = new Vector3(0.0f, 1.5f, 0.0f);
        float normalizedAngle = launchAngle / 90.0f;
        Vector3 angle = new Vector3(0.0f, normalizedAngle, (1.0f - normalizedAngle));
        Vector3 startingVelocity = angle * (launchSpeed1 / 50.0f);

        for (float t = 0.0f; t < numPoints; t += timeBetweenPoints) {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t;
            points.Add(newPoint);

            if (Physics.OverlapSphere(newPoint, 5, CollidableLayers).Length > 1) {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }
        lineRenderer.SetPositions(points.ToArray());
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
}
