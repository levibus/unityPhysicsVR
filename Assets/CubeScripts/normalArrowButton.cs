using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalArrowButton : MonoBehaviour
{
    public Oculus.Interaction.RoundedBoxProperties RBP;
    public Color materialColor1;
    public Color materialColor2;
    arrowUI arrowEM;
    bool test = false;

    void Start()
    {
        // RBP.Color = materialColor2;
        arrowEM = FindObjectOfType<arrowUI>();
        arrowEM.onNormal += changeColor;
    }

    void changeColor() {
        if (!test) {
            test = true;
            RBP.Color = materialColor1;
        }
        else {
            test = false;
            RBP.Color = materialColor2;            
        }
    }
}
