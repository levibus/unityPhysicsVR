using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/*
* Author: Levi Busching
* Description: Changes the text in the UI for the dynamic coefficient of friction.
*/

public class dynoFrictionText : MonoBehaviour
{
    angleEM angleEventManager;

    public GameObject cube;
    public TMP_Text label;

    Collider coll;
 
    private void Start()
    {
        coll = cube.GetComponent<Collider>();

        label.text = "0.3";
    }

    private void Update() {
        label.text = String.Format("{0:0.0}", coll.material.dynamicFriction);        // formats the float to only display the tenths place
    }

}