using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class normalArrowChange : MonoBehaviour
{
    public event Action onArrowDestruction;

    public GameObject arrow;
    public GameObject normalSnap;
    float spacing1 = 0.5f;
    bool active = true;

    normalModel model;
    
    void Start()
    {
        model = FindObjectOfType<normalModel>();
        model.onArrowPlacement += arrowOn;

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
        arrow.SetActive(true);
        active = true;
    }

    void ArrowDestruction() {
        if (onArrowDestruction != null) {
            onArrowDestruction();
        }
    }
}