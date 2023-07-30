// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: Toggles the color of the yGravitySnap box based on if the yGravity arrow is in the scene. It will be solid when the
*              arrow is active and foggy otherwise.
*/

public class yGravSnap : MonoBehaviour
{
    Renderer renderer;
    yGravityArrow yGrav;
    arrowUI arrowEM;
    
    public GameObject Snap;   // yGravSnap box
    public Material solid;    // same color as arrow
    public Material opague;   // same color as arrow but the alpha value is lower

    bool solidTest = true;    // true if material is solid
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        yGrav = FindObjectOfType<yGravityArrow>();
        yGrav.onArrowDestruction += toggle;
    }

    void toggle() {              // toggles the material
        if (!solidTest) {
            renderer.material = solid;
            solidTest = true;
        } else {
            renderer.material = opague;
            solidTest = false;
        }
    }

}
