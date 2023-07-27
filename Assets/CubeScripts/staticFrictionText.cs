using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class staticFrictionText : MonoBehaviour
{
    public TMP_Text label;
    angleEM angleEventManager;

    public GameObject cube;

    Collider coll;
 
    private void Start()
    {
        coll = cube.GetComponent<Collider>();

        label.text = "0.3";
    }

    private void Update() {
        label.text = String.Format("{0:0.0}", coll.material.staticFriction);        
    }

}