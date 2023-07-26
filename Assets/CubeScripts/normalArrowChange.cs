using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class normalArrowChange : MonoBehaviour
{
    public event Action onArrowDestruction;

    arrowUI arrowEM;

    public GameObject arrow;
    public GameObject normalSnap;

    float spacing1 = 0.15f;
    bool active = true;

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onNormal += arrowOn;

        arrow.SetActive(true);
    }

    void Update() {
        if (active && transform.position.x < normalSnap.transform.position.x + spacing1 && transform.position.y < normalSnap.transform.position.y + spacing1 && transform.position.z < normalSnap.transform.position.z + spacing1 && 
            transform.position.x > normalSnap.transform.position.x - spacing1 && transform.position.y > normalSnap.transform.position.y - spacing1 && transform.position.z > normalSnap.transform.position.z - spacing1) {
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