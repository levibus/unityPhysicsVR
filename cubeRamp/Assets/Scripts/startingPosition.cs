using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingPosition : MonoBehaviour
{
    private Vector3 position;

    public startingPosition(float height) {
        this.position = new Vector3(0.0f, height, 0.0f);
    }

    public void setPosition(float height) {
        this.position.y = height;
    }

    public Vector3 getPosition() {
        return position;
    }
}
