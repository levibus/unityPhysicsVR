using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class angleText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    angleEM angleEventManager;
    speedEM speedEventManager;

    public float launchAngle = 45.0f;
    public float launchSpeed = 500.0f;
 
    private void Start()
    {
        // Get a reference to the text component.
        // Since we are using the base class type <TMP_Text> this component could be either a <TextMeshPro> or <TextMeshProUGUI> component.
        text.text = "Angle: " + launchAngle + "\u00B0" + "\n" + "Force: " + (launchSpeed / 10f) + "N";

        angleEventManager = FindObjectOfType<angleEM>();
        angleEventManager.onAngleIncrease += increaseAngle;
        angleEventManager.onAngleDecrease += decreaseAngle;

        speedEventManager = FindObjectOfType<speedEM>();
        speedEventManager.onSpeedIncrease += increaseSpeed;
        speedEventManager.onSpeedDecrease += decreaseSpeed;
    }

    private void Update() {
        text.text = "Angle: " + launchAngle + "\u00B0" + "\n" + "Force: " + (launchSpeed / 10f) + "N";
    }

    void increaseAngle() {
        if (launchAngle < 90.0f) {
            launchAngle += 5.0f;
        }
    }

    void decreaseAngle() {
        if (launchAngle > 0.0f) {
            launchAngle -= 5.0f;
        }
    } 

    void increaseSpeed() {
        if (launchSpeed < 1000.0f) {
            launchSpeed += 100.0f;
        }
    }

    void decreaseSpeed() {
        if (launchSpeed > 0.0f) {
            launchSpeed -= 100.0f;
        }
    } 
}