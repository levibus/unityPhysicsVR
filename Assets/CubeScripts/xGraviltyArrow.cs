using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xGravityArrow : MonoBehaviour
{
    public GameObject arrow;
    arrowUI arrowEM;
    bool test = false;

    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onXGravity += changeActive;
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