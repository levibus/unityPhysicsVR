using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: Toggles the color of the normalSnap box based on if the normal arrow is in the scene. It will be solid when the
*              arrow is active and foggy otherwise.
*/

public class normalSnapColor : MonoBehaviour
{
    Renderer renderer;
    normalArrowChange arrow;
    arrowUI arrowEM;

    public GameObject Snap;     // the normalSnap box
    public Material solid;      // same color as arrow
    public Material opague;     // same color as arrow but the alpha value is lower

    bool solidTest = true;      // true if material is solid
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        arrow = FindObjectOfType<normalArrowChange>();
        arrow.onArrowDestruction += toggle;
    }

    void toggle() {                   // toggles materail
        if (!solidTest) {
            renderer.material = solid;
            solidTest = true;
        } else {
            renderer.material = opague;
            solidTest = false;
        }
    }

}
