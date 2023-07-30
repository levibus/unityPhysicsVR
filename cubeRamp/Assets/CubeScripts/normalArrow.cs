using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: Handles the position, orientation, and scaling of the normal, xGravity, yGravity, and friction arrows.
*              It uses a raycast pointed at the center of the cube in order to know the normal vector at that position.
*/

public class normalArrow : MonoBehaviour
{
    frictionUI DynoFrictionEM;

    public GameObject cubeHolder;          // the cube
    public GameObject origin;              // the origin of the raycast
    public GameObject pivot;
    public GameObject anchor;
    public GameObject normalArrowObject;   // normal arrow
    public GameObject yArrowHolder;        // yGravity arrow
    public GameObject xArrowHolder;        // xGravity arrow
    public GameObject frictionArrow;       // friction arrow
    public LayerMask mask;
    public Rigidbody rb;                   // cube Rigidbody

    Vector3 nintyDegrees = new Vector3(90.0f, 0.0f, 0.0f);         // changes x angle by 90 degrees
    Vector3 reverseDirection = new Vector3(180.0f, 0.0f, 0.0f);    // changes x angle by 180 degrees

    float gravity = 9.81f;
    float scaleDown = 0.1f;       // scale the arrows to a reasonable size
    float xGravityXCoordinate;    // used to create a 90 degree angle between the x and y gravity components
    float distance = 10;          // length of the raycast if it doesn't hit anything
    int layerMask = 1<<7;         // used to make sure the raycast only activates upon hitting the board or ground (not cube or arrows)
    float angle;                  // x component of the normal from the raycast
    float dynamicFriction = 0.3f; // good starting value

    void Start() {
        DynoFrictionEM = FindObjectOfType<frictionUI>();
        DynoFrictionEM.onDynoFrictionIncrease += increaseDynoFriction;
        DynoFrictionEM.onDynoFrictionDecrease += decreaseDynoFriction;
    }
    
    void Update() {
        Vector3 direction = cubeHolder.transform.position - origin.transform.position;      // the direction that the raycast points
        RaycastHit hitInfo;
    
        // actives if the raycast hits the board or ground when pointing towards the center of the cube.
        // it will give the angle of the normal vector in the place where the raycast hits
        if (Physics.Raycast(origin.transform.position, direction, out hitInfo, distance, layerMask)) {
            normalArrowObject.transform.position = cubeHolder.transform.position;     // arrow starts in the center of the cube
            normalArrowObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);      // normal
            yArrowHolder.transform.position = cubeHolder.transform.position;
            yArrowHolder.transform.rotation = Quaternion.FromToRotation(Vector3.up, (-1.0f * hitInfo.normal)); // opposite from normal
            xArrowHolder.transform.position = cubeHolder.transform.position;
            xGravityXCoordinate = yArrowHolder.transform.eulerAngles.x + 90.0f;
            xArrowHolder.transform.eulerAngles = new Vector3(xGravityXCoordinate, 180.0f, 180.0f);     // 90 degrees different from yGravity
            frictionArrow.transform.position = cubeHolder.transform.position;
            frictionArrow.transform.eulerAngles = xArrowHolder.transform.eulerAngles + reverseDirection;   // opposite direction from xGravity

            angle = normalArrowObject.transform.eulerAngles.x;        // x component of the normal from the raycast
        }
     scaleArrows(angle);

        // turns off friction and xGravity arrows when the cube hits the ground
        if (rb.velocity.magnitude < 0.01f && rb.position != anchor.transform.position) {
            xArrowHolder.SetActive(false);
            frictionArrow.SetActive(false);
        }
        else {
            xArrowHolder.SetActive(true);
            frictionArrow.SetActive(true);
        }
    }

    void scaleArrows(float angleDeg) {
        float angleRad = angleDeg * Mathf.PI / 180f;     
        float scale = gravity * Mathf.Cos(angleRad);        // x componenet of gravity
        float smallerScaleY = scale * scaleDown;            // scaled down to a reasonable size
        yArrowHolder.transform.localScale = new Vector3(0.25f, smallerScaleY, 0.25f);
        normalArrowObject.transform.localScale = new Vector3(0.25f, smallerScaleY, 0.25f);

        float insideMath = (gravity * gravity) - (scale * scale);    // finding y component of gravity through Pythagorean Theorem
        if (insideMath < 0.0f) {     // so that the inside of the sqrt in line 86 isn't negative
            insideMath = 0.0f;
        }

        float smallerScaleX = Mathf.Sqrt(insideMath) * scaleDown;
        xArrowHolder.transform.localScale = new Vector3(0.25f, smallerScaleX, 0.25f);
        frictionArrow.transform.localScale = new Vector3(0.25f, smallerScaleY * dynamicFriction / 2.0f + 0.03f, 0.25f);   // trying to make the friction scaling right

        if (dynamicFriction < 0.1f) {
            frictionArrow.transform.localScale = new Vector3(0.25f, 0.0f, 0.25f);       // makes sure friction isn't negative
        }
    }

    void increaseDynoFriction() {
        if (dynamicFriction < 0.99) {
            dynamicFriction += 0.1f;
        }
    }

    void decreaseDynoFriction() {
        if (dynamicFriction > 0.01) {
            dynamicFriction -= 0.1f;
        }
    }
}
