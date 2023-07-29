using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: Toggles the color of the velocitySnap box based on if the velocity arrow is in the scene. It will be solid when the
*              arrow is active and foggy otherwise.
*              (it will remain solid when the velocity arrow is destroyed after the cube hits the ground, because the velocity arrow
*               is still deployed in the scene)
*/

public class velSnap : MonoBehaviour
{
    Renderer renderer;
    velocityArrow arrow;
    arrowUI arrowEM;
    
    public GameObject Snap;    // velocitySnap box
    public Material solid;     // same color as arrow
    public Material opague;    // same color as arrow but the alpha value is lower

    bool solidTest = true;     // true if the material is solid
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        arrow = FindObjectOfType<velocityArrow>();
        arrow.onArrowDestruction += toggle;
    }

    void toggle() {               // toggles material
        if (!solidTest) {
            renderer.material = solid;
            solidTest = true;
        } else {
            renderer.material = opague;
            solidTest = false;
        }
    }

}
