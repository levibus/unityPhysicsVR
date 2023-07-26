using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class yGravityArrow : MonoBehaviour
{
    public event Action onArrowDestruction;

    arrowUI arrowEM;

    public GameObject yGravSnap;
    public GameObject arrow;

    float spacing1 = 0.15f;
    bool active = true;

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onYGravity += arrowOn;

        arrow.SetActive(true);
    }

    void Update() {
        if (active && transform.position.x < yGravSnap.transform.position.x + spacing1 && transform.position.y < yGravSnap.transform.position.y + spacing1 && transform.position.z < yGravSnap.transform.position.z + spacing1 && 
            transform.position.x > yGravSnap.transform.position.x - spacing1 && transform.position.y > yGravSnap.transform.position.y - spacing1 && transform.position.z > yGravSnap.transform.position.z - spacing1) {
            active = false;
            arrow.SetActive(false);
            ArrowDestruction();
        }
    }

    void arrowOn() {
        if (!active) {
            arrow.SetActive(true);
            active = true;
            ArrowDestruction();
        }
        else {
            arrow.SetActive(false);
            active = false;
            ArrowDestruction();
        }
    }

    void ArrowDestruction() {
        if (onArrowDestruction != null) {
            onArrowDestruction();
        }
    }
}