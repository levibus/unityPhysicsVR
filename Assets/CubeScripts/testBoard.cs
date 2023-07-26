using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBoard : MonoBehaviour
{
    boardAngleEM boardAngle;
    public GameObject pivot;
    float angle = 45.0f;

    void Start() {
        boardAngle = FindObjectOfType<boardAngleEM>();
        boardAngle.onAngleIncrease += increaseAngle;
        boardAngle.onAngleDecrease += decreaseAngle;
    }

    void Update() {
        setBoard();
    }

    void setBoard() {
        // float normalizedAngle = angle / 90.0f;
        pivot.transform.eulerAngles = new Vector3(angle, 90.0f, 0.0f);
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
}
