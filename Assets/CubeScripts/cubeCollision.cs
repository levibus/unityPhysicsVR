using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Signals when the cube hits the ground (so that some of the arrows can be destroyed)
*/

public class cubeCollision : MonoBehaviour
{
    public event Action onGroundCollision;

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.name == "Plane") {            // when the cube collides with the ground
            GroundCollision();
        }
    }

    void GroundCollision() {
        if (onGroundCollision != null) {
            onGroundCollision();
        }
    }

}
