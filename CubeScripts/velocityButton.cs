using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityButton : MonoBehaviour
{
    public GameObject button;
    Renderer renderer;
    public Material materialColor1;
    public Material materialColor2;
    arrowUI arrowEM;
    bool test = false;

    void Start()
    {
        renderer = button.GetComponent<Renderer>();
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onVelocity += changeColor;
    }

    void changeColor() {
        if (!test) {
            test = true;
            renderer.material = materialColor2;
        }
        else {
            test = false;
            renderer.material = materialColor1;
        }
    }
}
