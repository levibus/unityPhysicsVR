using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velSnap : MonoBehaviour
{
    public GameObject Snap;
    public Material solid;
    public Material opague;
    bool solidTest = true;
    
    Renderer renderer;
    velocityArrow arrow;
    arrowUI arrowEM;
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        arrow = FindObjectOfType<velocityArrow>();
        arrow.onArrowDestruction += toggle;
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
