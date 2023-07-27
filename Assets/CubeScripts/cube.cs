using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    launchEM launch;
    frictionUI DynoFrictionEM;
    visibleUI visibleEM;

    public GameObject anchor;
    public GameObject pivot;
    public GameObject block;
    public Rigidbody rb;

    Collider coll;
    MeshRenderer MR;

    int test = 1;
    bool active = false;
    float dynamicFriction = 0.3f;   // good starting value
    float staticFriction = 0.3f;  

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

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
