using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: Takes care of the cube GameObject: including the position, orientation, gravity, coefficient of friction, and visibility.
*/

public class cube : MonoBehaviour
{
    launchEM launch;
    frictionUI DynoFrictionEM;
    visibleUI visibleEM;

    public GameObject anchor;
    public GameObject pivot;
    public GameObject block;        // the cube (couldn't name it "cube" as this is the script name)
    public Rigidbody rb;            // Rigidbody of the cube

    Collider coll;
    MeshRenderer MR;

    bool test = true;               // if the cube is at the starting position
    bool active = false;            // if the cube is visible
    float dynamicFriction = 0.3f;   // good starting value
    float staticFriction = 0.3f;  

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;     // no gravity before launch

        coll = GetComponent<Collider>();
        MR = GetComponent<MeshRenderer>();

        launch = FindObjectOfType<launchEM>();
        launch.onLaunch += Launch;
        launch.onReset += Reset;

        DynoFrictionEM = FindObjectOfType<frictionUI>();
        DynoFrictionEM.onDynoFrictionIncrease += increaseDynoFriction;
        DynoFrictionEM.onDynoFrictionDecrease += decreaseDynoFriction;
        DynoFrictionEM.onStaticFrictionIncrease += increaseStaticFriction;
        DynoFrictionEM.onStaticFrictionDecrease += decreaseStaticFriction;

        visibleEM = FindObjectOfType<visibleUI>();
        visibleEM.onBlock += toggleVisibility;
    }

    void Update() { 
        if (test) {         // moves cube to starting position/orientation
            transform.position = anchor.transform.position;                 
            transform.eulerAngles = pivot.transform.eulerAngles;
        }
        coll.material.dynamicFriction = dynamicFriction;
        coll.material.staticFriction = staticFriction;
    }

    void Launch() {
        test = false;
        rb.useGravity = true;
    }

    void Reset() {
        test = true;
        rb.useGravity = false;
        transform.position = anchor.transform.position;
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

    void increaseStaticFriction() {
        if (staticFriction < 0.99) {
            staticFriction += 0.1f;
        }
    }

    void decreaseStaticFriction() {
        if (staticFriction > 0.01) {
            staticFriction -= 0.1f;
        }
    }

    void toggleVisibility() {
        if (active) {
            MR.enabled = false;
            active = false;
        }
        else {
            MR.enabled = true;
            active = true;
        }
    }

}
