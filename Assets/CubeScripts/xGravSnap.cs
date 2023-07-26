// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xGravSnap : MonoBehaviour
{
    public GameObject Snap;
    public Material solid;
    public Material opague;
    bool solidTest = true;
    
    Renderer renderer;
    xGravityArrow xGrav;
    arrowUI arrowEM;
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        xGrav = FindObjectOfType<xGravityArrow>();
        xGrav.onArrowDestruction += toggle;
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
