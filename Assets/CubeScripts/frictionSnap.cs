using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frictionSnap : MonoBehaviour
{
    public GameObject Snap;
    public Material solid;
    public Material opague;

    Renderer renderer;
    frictionArrow frictionArr;
    arrowUI arrowEM;
    
    void Start()
    {
        renderer = Snap.GetComponent<Renderer>();
        renderer.material = solid;

        frictionArr = FindObjectOfType<frictionArrow>();
        frictionArr.onArrowDestruction += makeOpague;

        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onFriction += makeSolid;
    }

    void makeOpague() {
        renderer.material = opague;
    }

    void makeSolid() {
        renderer.material = solid;
    }

}
