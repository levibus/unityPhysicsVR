// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xGravSnap : MonoBehaviour
{
    public GameObject Snap;
    public Material solid;
    public Material opague;
    Renderer renderer;
    xGravityArrow xGrav;

    arrowUI arrowEM;
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        xGrav = FindObjectOfType<xGravityArrow>();
        xGrav.onArrowDestruction += makeOpague;

        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onXGravity += makeSolid;
    }

    void makeOpague() {
        renderer.material = opague;
    }

    void makeSolid() {
        renderer.material = solid;
    }

}
