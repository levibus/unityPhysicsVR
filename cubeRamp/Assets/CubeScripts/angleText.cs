using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/*
*  Author: Levi Busching
*  Description: Changes the angle of the ramp incline displayed in the UI.
*/

public class angleText2 : MonoBehaviour
{
    angleEM angleEventManager;

    public TMP_Text label;
    public GameObject pivot;

    int textNum;
 
    private void Start()
    {
        label.text = 45 + "\u00B0";                // 45 with the degree symbol
    }

    private void Update() {
        textNum = (int) (pivot.transform.eulerAngles.x + 0.5f);         // takes angle from the angle of the pivot
        label.text = textNum + "\u00B0";        
    }

}