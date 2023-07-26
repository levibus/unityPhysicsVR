using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class angleText2 : MonoBehaviour
{
    public TMP_Text label;
    angleEM angleEventManager;

    public GameObject pivot;
 
    private void Start()
    {
        // Get a reference to the text component.
        // Since we are using the base class type <TMP_Text> this component could be either a <TextMeshPro> or <TextMeshProUGUI> component.
        label.text = "shaye gay";
        transform.position = new Vector3(0.0f, 1.0f, -0.5f);
    }

    private void Update() {
        label.text = "shaye gay";
        transform.position = new Vector3(0.0f, 1.0f, -0.5f);
    }

}