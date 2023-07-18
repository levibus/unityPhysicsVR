using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    launchEM launch;
    public GameObject anchor;
    public GameObject pivot;
    public Rigidbody rb;
    int test = 1;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        launch = FindObjectOfType<launchEM>();
        launch.onLaunch += Launch;
        launch.onReset += Reset;
    }

    void Update() {
        if (test == 1) {
            transform.position = anchor.transform.position;
            transform.eulerAngles = pivot.transform.eulerAngles;
        }
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

}
