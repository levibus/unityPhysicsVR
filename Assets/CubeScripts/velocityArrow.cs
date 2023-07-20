using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityArrow : MonoBehaviour
{
    public GameObject arrow;
    arrowUI arrowEM;
    bool test = false;

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onVelocity += changeActive;
    }

    void changeActive() {
        if (!test) {
            test = true;
            arrow.SetActive(false);
        }
        else {
            test = false;
            arrow.SetActive(true);
        }
    }
}