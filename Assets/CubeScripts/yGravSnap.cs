// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yGravSnap : MonoBehaviour
{
    public GameObject Snap;
    public Material solid;
    public Material opague;
    
    Renderer renderer;
    yGravityArrow yGrav;
    arrowUI arrowEM;
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        yGrav = FindObjectOfType<yGravityArrow>();
        yGrav.onArrowDestruction += makeOpague;

        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onYGravity += makeSolid;
    }

    void makeOpague() {
        renderer.material = opague;
    }

    void makeSolid() {
        renderer.material = solid;
    }

}
