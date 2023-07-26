using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velSnap : MonoBehaviour
{
    public GameObject Snap;
    public Material solid;
    public Material opague;

    Renderer renderer;
    velocityArrow velArrow;
    arrowUI arrowEM;
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        velArrow = FindObjectOfType<velocityArrow>();
        velArrow.onArrowDestruction += makeOpague;

        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onVelocity += makeSolid;
    }

    void makeOpague() {
        renderer.material = opague;
    }

    void makeSolid() {
        renderer.material = solid;
    }

}
