using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawProjection : MonoBehaviour
{
    public ObjectCenter objectCenter;
    LineRenderer lineRenderer;

    public int numPoints = 50;

    public float timeBetweenPoints = 0.1f;

    public LayerMask CollidableLayers;
    
    // Start is called before the first frame update
    void Start()
    {
        objectCenter = GetComponent<ObjectCenter>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = new Vector3(0.0f, 1.5f, 0.0f);
        Vector3 startingVelocity = new Vector3(objectCenter.launchAngle, 90.0f, 0.0f) * objectCenter.launchSpeed;

        for (float t = 0.0f; t < numPoints; t += timeBetweenPoints) {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t;
            points.Add(newPoint);

            if (Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0) {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }
        lineRenderer.SetPositions(points.ToArray());
    }
}
