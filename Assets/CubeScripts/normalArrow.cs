using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalArrow : MonoBehaviour
{
    frictionUI DynoFrictionEM;

    public LayerMask mask;
    public GameObject normalArrowObject;
    public GameObject cubeHolder;
    public GameObject origin;
    public GameObject pivot;
    public GameObject anchor;
    public GameObject yArrowHolder;
    public GameObject xArrowHolder;
    public GameObject frictionArrow;
    public Rigidbody rb;

    Vector3 nintyDegrees = new Vector3(90.0f, 0.0f, 0.0f);
    Vector3 reverseDirection = new Vector3(180.0f, 0.0f, 0.0f);

    float gravity = 9.81f;
    float scaleDown = 0.1f;
    float xGravityXCoordinate;
    float distance = 10;
    int layerMask = 1<<7;
    float angle;
    float dynamicFriction = 0.3f;

    void Start() {
        DynoFrictionEM = FindObjectOfType<frictionUI>();
        DynoFrictionEM.onDynoFrictionIncrease += increaseDynoFriction;
        DynoFrictionEM.onDynoFrictionDecrease += decreaseDynoFriction;
    }
    
    void Update() {
        Vector3 direction = cubeHolder.transform.position - origin.transform.position;
        RaycastHit hitInfo;
    
        if (Physics.Raycast(origin.transform.position, direction, out hitInfo, distance, layerMask)) {
            normalArrowObject.transform.position = cubeHolder.transform.position;
            normalArrowObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            yArrowHolder.transform.position = cubeHolder.transform.position;
            yArrowHolder.transform.rotation = Quaternion.FromToRotation(Vector3.up, (-1.0f * hitInfo.normal));
            xArrowHolder.transform.position = cubeHolder.transform.position;
            xGravityXCoordinate = yArrowHolder.transform.eulerAngles.x + 90.0f;
            xArrowHolder.transform.eulerAngles = new Vector3(xGravityXCoordinate, 180.0f, 180.0f);
            frictionArrow.transform.position = cubeHolder.transform.position;
            frictionArrow.transform.eulerAngles = xArrowHolder.transform.eulerAngles + reverseDirection;

            angle = normalArrowObject.transform.eulerAngles.x;
        }
     scaleArrows(angle);

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
        float scale = gravity * Mathf.Cos(angleRad);
        float smallerScaleY = scale * scaleDown;
        yArrowHolder.transform.localScale = new Vector3(0.25f, smallerScaleY, 0.25f);
        normalArrowObject.transform.localScale = new Vector3(0.25f, smallerScaleY, 0.25f);

        float insideMath = (gravity * gravity) - (scale * scale);
        if (insideMath < 0.0f) {
            insideMath = 0.0f;
        }

        float smallerScaleX = Mathf.Sqrt(insideMath) * scaleDown;
        xArrowHolder.transform.localScale = new Vector3(0.25f, smallerScaleX, 0.25f);
        frictionArrow.transform.localScale = new Vector3(0.25f, smallerScaleY * dynamicFriction / 2.0f + 0.03f, 0.25f);

        if (dynamicFriction < 0.1f) {
            frictionArrow.transform.localScale = new Vector3(0.25f, 0.0f, 0.25f);
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
