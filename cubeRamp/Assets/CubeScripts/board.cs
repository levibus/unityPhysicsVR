using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: Changes the angle of the board and whether or not it is visible.
*/

public class board : MonoBehaviour
{
    boardAngleEM boardAngle;
    visibleUI visibleEM;

    public GameObject pivot;               // the pivot (parent of the board)
    public GameObject boardObject;         // the board
 
    MeshRenderer MR;

    float angle = 45.0f;
    bool active = false;   // true if the board is visible

    void Start() {
        boardAngle = FindObjectOfType<boardAngleEM>();     // changes angle
        boardAngle.onAngleIncrease += increaseAngle;
        boardAngle.onAngleDecrease += decreaseAngle;

        visibleEM = FindObjectOfType<visibleUI>();         // changes visibility of board
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
