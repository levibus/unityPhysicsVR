using UnityEngine;

public class InclinedPlane : MonoBehaviour
{
    public float rampAngle = 30f;         // Angle of the ramp in degrees
    public float frictionCoefficient = 0.1f;  // Friction coefficient
    public float initialVelocity = 5f;   // Initial velocity of the block
    
    private Vector3 inclinedDirection;   // Direction of the inclined plane
    private float accelerationAlongRamp; // Acceleration of the block along the inclined plane
    private float normalForce;           // Normal force acting on the block
    private float frictionForce;         // Frictional force acting on the block

    private void Start()
    {
        // Calculate the direction of the inclined plane (ignoring Z component)
        inclinedDirection = Quaternion.Euler(-rampAngle, 0f, 0f) * Vector3.right;
        inclinedDirection.z = 0f;
        inclinedDirection.Normalize();
        Debug.Log(inclinedDirection);

        // Calculate the acceleration of the block along the inclined plane
        accelerationAlongRamp = Physics.gravity.magnitude * Mathf.Sin(rampAngle * Mathf.Deg2Rad) - frictionCoefficient * Physics.gravity.magnitude * Mathf.Cos(rampAngle * Mathf.Deg2Rad);
        Debug.Log(accelerationAlongRamp);

        // Calculate the normal force acting on the block
        normalForce = GetComponent<Rigidbody>().mass * Mathf.Cos(rampAngle * Mathf.Deg2Rad);
        Debug.Log(normalForce);

        // Calculate the frictional force acting on the block
        frictionForce = frictionCoefficient * normalForce;

        // Set the initial velocity of the block along the inclined plane
        Vector3 initialVelocityVector = inclinedDirection * initialVelocity;
        Debug.Log(initialVelocityVector);
        GetComponent<Rigidbody>().velocity = initialVelocityVector;
    }

    private void Update()
    {
        // Calculate the current velocity vector along the inclined plane
        Vector3 currentVelocity = GetComponent<Rigidbody>().velocity;
        Vector3 currentVelocityAlongRamp = Vector3.Dot(currentVelocity, inclinedDirection) * inclinedDirection;

        // Calculate the acceleration of the block along the inclined plane
        Vector3 acceleration = accelerationAlongRamp * inclinedDirection;

        // Calculate the net force acting on the block
        Vector3 netForce = GetComponent<Rigidbody>().mass * acceleration;

        // Calculate the frictional force acting on the block
        Vector3 frictionForceVector = -frictionForce * currentVelocityAlongRamp.normalized;

        // Apply the net force and frictional force to the block
        GetComponent<Rigidbody>().AddForce(netForce + frictionForceVector, ForceMode.Force);
    }
}