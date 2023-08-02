using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Levi Busching
* Description: A class to keep track of the starting position of the ball with getters and setters.
*/

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
