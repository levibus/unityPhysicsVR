using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalSnapColor : MonoBehaviour
{
    public GameObject normalSnap;
    public Material solid;
    public Material opague;
    Renderer renderer;
    normalArrowChange normalChange;
    normalModel model;
    
    void Start()
    {
        renderer = normalSnap.GetComponent<Renderer>();
        renderer.material = solid;

        normalChange = FindObjectOfType<normalArrowChange>();
        normalChange.onArrowDestruction += makeOpague;

        model = FindObjectOfType<normalModel>();
        model.onArrowPlacement += makeSolid;
    }

    void makeOpague() {
        renderer.material = opague;
    }

    void makeSolid() {
        renderer.material = solid;
    }

}
