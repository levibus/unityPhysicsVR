using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Toggles the visibility (activity) of the normal arrow.
*              Along with the rest of the arrows, it can be turned on and off by touching the normalSnap UI button, or can be 
*              turned off by holding it close to the normalSnap box.
*/

public class normalArrowChange : MonoBehaviour
{
    public event Action onArrowDestruction;

    arrowUI arrowEM;

    public GameObject arrow;
    public GameObject normalSnap;          // the colored box related to the normal arrow UI

    float spacing1 = 0.15f;                // the spacing away from the center of the normalSnap box in every direction
    bool active = true;                    // if the arrow is active

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onNormal += arrowOn;

        arrow.SetActive(true);            // starts as active
    }

    void Update() {
        // checks if the arrow is active and "spacing1" away from the center of the normalSnap box in every direction
        if (active && transform.position.x < normalSnap.transform.position.x + spacing1 && transform.position.y < normalSnap.transform.position.y + spacing1 && transform.position.z < normalSnap.transform.position.z + spacing1 && 
            transform.position.x > normalSnap.transform.position.x - spacing1 && transform.position.y > normalSnap.transform.position.y - spacing1 && transform.position.z > normalSnap.transform.position.z - spacing1) {
            active = false;
            arrow.SetActive(false);
            ArrowDestruction();
        }
    }

    void arrowOn() {                         // toggles if the arrow is active or not
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

    void ArrowDestruction() {                 // event that toggles when the arrow activity status is changed
        if (onArrowDestruction != null) {
            onArrowDestruction();
        }
    }
}