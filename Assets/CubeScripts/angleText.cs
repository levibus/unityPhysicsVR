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
    int textNum;
 
    private void Start()
    {
        label.text = 45 + "\u00B0";
    }

    private void Update() {
        textNum = (int) (pivot.transform.eulerAngles.x + 0.5f);
        label.text = textNum + "\u00B0";        
    }

}