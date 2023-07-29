// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: Toggles the color of the xGravitySnap box based on if the xGravity arrow is in the scene. It will be solid when the
*              arrow is active and foggy otherwise.
*              (it will remain solid when the xGravity arrow is destroyed after the cube hits the ground, because the xGravity arrow
*               is still deployed in the scene)
*/

public class xGravSnap : MonoBehaviour
{
    Renderer renderer;
    xGravityArrow xGrav;
    arrowUI arrowEM;
    
    public GameObject Snap;   // xGravSnap box
    public Material solid;    // same color as arrow
    public Material opague;   // same color as arrow but the alpha value is lower

    bool solidTest = true;    // true when material is solid
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        xGrav = FindObjectOfType<xGravityArrow>();
        xGrav.onArrowDestruction += toggle;
    }

    void toggle() {                  // toggles the material
        if (!solidTest) {
            renderer.material = solid;
            solidTest = true;
        } else {
            renderer.material = opague;
            solidTest = false;
        }
    }

}
