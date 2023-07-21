using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class normalModel : MonoBehaviour
{
    public GameObject arrow;
    public GameObject normalSnap;
    public GameObject arrowModel;
    public Material material1;
    public Material material2;
    Renderer renderer;

    void Start()
    {
        renderer = normalSnap.GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.collider.name);
        if (collision.collider.name == "placeArrows") {
            arrow.SetActive(true);
            arrowModel.transform.position = normalSnap.transform.position;
            renderer.material = material2;
        }
    }
}