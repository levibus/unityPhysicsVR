using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    launchEM launch;
    frictionUI DynoFrictionEM;

    public GameObject anchor;
    public GameObject pivot;

    Collider coll;
    public Rigidbody rb;
    int test = 1;
    float dynamicFriction = 0.3f;   // good starting value
    float staticFriction = 0.3f;  

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        coll = GetComponent<Collider>();

        launch = FindObjectOfType<launchEM>();
        launch.onLaunch += Launch;
        launch.onReset += Reset;

        DynoFrictionEM = FindObjectOfType<frictionUI>();
        DynoFrictionEM.onDynoFrictionIncrease += increaseDynoFriction;
        DynoFrictionEM.onDynoFrictionDecrease += decreaseDynoFriction;
        DynoFrictionEM.onStaticFrictionIncrease += increaseStaticFriction;
        DynoFrictionEM.onStaticFrictionDecrease += decreaseStaticFriction;
    }

    void Update() {
        if (test == 1) {
            transform.position = anchor.transform.position;
            transform.eulerAngles = pivot.transform.eulerAngles;
        }
        coll.material.dynamicFriction = dynamicFriction;
        coll.material.staticFriction = staticFriction;
    }

    void Launch() {
        test = 0;
        rb.useGravity = true;
    }

    void Reset() {
        test = 1;
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

}
