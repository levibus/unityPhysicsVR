using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: Toggles the color of the frictionSnap box based on if the friction arrow is in the scene. It will be solid when the
*              arrow is active and foggy otherwise.
*              (it will remain solid when the friction arrow is destroyed after the cube hits the ground, because the friction arrow
*               is still deployed in the scene)
*/

public class frictionSnap : MonoBehaviour
{
    Renderer renderer;
    frictionArrow arrow;
    arrowUI arrowEM;

    public GameObject Snap;         // the frictionSnap box
    public Material solid;          // same color as arrow
    public Material opague;         // same color as arrow but the alpha value is lower

    bool solidTest = true;          // true if frictionSnap is of the material "solid"
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        arrow = FindObjectOfType<frictionArrow>();
        arrow.onArrowDestruction += toggle;
    }

    void toggle() {                        // toggles the material
        if (!solidTest) {
            renderer.material = solid;
            solidTest = true;
        } else {
            renderer.material = opague;
            solidTest = false;
        }
    }

}
