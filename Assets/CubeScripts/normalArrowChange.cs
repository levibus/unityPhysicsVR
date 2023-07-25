using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class normalArrowChange : MonoBehaviour
{
    public GameObject arrow;
    public GameObject normalSnap;
    public GameObject arrowModel;
    public GameObject cube;
    arrowUI arrowEM;
    bool test = false;
    public Material material1;
    public Material material2;
    Renderer renderer;
    float spacing1 = 0.5f;
    float spacing2 = 0.5f;
    
    void Start()
    {
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onNormal += changeActive;

        arrow.SetActive(true);
        arrowModel.SetActive(false);

        renderer = normalSnap.GetComponent<Renderer>();
        renderer.material = material1;
    }

    void changeActive() {
        if (!test) {
            test = true;
            arrowOff();
        }
        else {
            test = false;
            arrowOn();
        }
    }

    void Update() {
        if (transform.position.x < normalSnap.transform.position.x + spacing1 && transform.position.y < normalSnap.transform.position.y + spacing1 && transform.position.z < normalSnap.transform.position.z + spacing1 && 
            transform.position.x > normalSnap.transform.position.x - spacing1 && transform.position.y > normalSnap.transform.position.y - spacing1 && transform.position.z > normalSnap.transform.position.z - spacing1) {
            arrowOff();
        }
        else if (arrowModel.transform.position.x < cube.transform.position.x + spacing2 && arrowModel.transform.position.y < cube.transform.position.y + spacing2 && arrowModel.transform.position.z < cube.transform.position.z + spacing2 && 
            arrowModel.transform.position.x > cube.transform.position.x - spacing2 && arrowModel.transform.position.y > cube.transform.position.y - spacing2 && arrowModel.transform.position.z > cube.transform.position.z - spacing2) {
            arrowOn();
        }
    }

    void arrowOff() {
        arrow.transform.position = cube.transform.position;
        arrow.SetActive(false);
        arrowModel.SetActive(true);
        arrowModel.transform.position = normalSnap.transform.position;
        arrowModel.transform.eulerAngles = Vector3.up;
        renderer.material = material2;
    }

    void arrowOn() {
        arrow.SetActive(true);
        arrowModel.transform.position = normalSnap.transform.position;
        arrowModel.SetActive(false);
        renderer.material = material1;
    }
}