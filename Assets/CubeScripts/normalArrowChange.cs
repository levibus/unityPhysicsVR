using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class normalArrowChange : MonoBehaviour
{
    public GameObject arrow;
    public GameObject normalSnap;
    public GameObject arrowModel;
    arrowUI arrowEM;
    bool test = false;
    public Material material1;
    public Material material2;
    Renderer renderer;
    
    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onNormal += changeActive;

        renderer = normalSnap.GetComponent<Renderer>();
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

    void Update() {
        if (transform.position.x < normalSnap.transform.position.x + 1 && transform.position.y < normalSnap.transform.position.y + 1 && transform.position.z < normalSnap.transform.position.z + 1 && 
            transform.position.x > normalSnap.transform.position.x - 1 && transform.position.y > normalSnap.transform.position.y - 1 && transform.position.z > normalSnap.transform.position.z - 1) {
                arrow.SetActive(false);
                renderer.material = material1;
            }
    }
}
