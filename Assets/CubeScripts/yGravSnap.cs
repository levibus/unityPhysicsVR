// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yGravSnap : MonoBehaviour
{
    public GameObject Snap;
    public Material solid;
    public Material opague;
    bool solidTest = true;
    
    Renderer renderer;
    yGravityArrow yGrav;
    arrowUI arrowEM;
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        yGrav = FindObjectOfType<yGravityArrow>();
        yGrav.onArrowDestruction += toggle;
    }

    void toggle() {
        if (!solidTest) {
            renderer.material = solid;
            solidTest = true;
        } else {
            renderer.material = opague;
            solidTest = false;
        }
    }

}
