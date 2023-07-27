using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    boardAngleEM boardAngle;
    visibleUI visibleEM;

    public GameObject pivot;
    public GameObject boardObject;

    MeshRenderer MR;

    float angle = 45.0f;
    bool active = false;

    void Start() {
        boardAngle = FindObjectOfType<boardAngleEM>();
        boardAngle.onAngleIncrease += increaseAngle;
        boardAngle.onAngleDecrease += decreaseAngle;

        visibleEM = FindObjectOfType<visibleUI>();
        visibleEM.onBoard += toggleVisibility;

        MR = boardObject.GetComponent<MeshRenderer>();
    }

    void Update() {
        setBoard();
    }

    void setBoard() {
        pivot.transform.eulerAngles = new Vector3(angle, 0.0f, 0.0f);
    }

    void increaseAngle() {
        if (angle < 89.9) {
            angle += 5.0f;
        }
    }

    void decreaseAngle() {
        if (angle > 0.1) {
            angle -= 5.0f;
        }
    }

    void toggleVisibility() {
        if (active) {
            MR.enabled = false;
            active = false;
        }
        else {
            MR.enabled = true;
            active = true;
        }
    }

}
