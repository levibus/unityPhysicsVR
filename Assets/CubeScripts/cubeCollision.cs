using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cubeCollision : MonoBehaviour
{
    public event Action onGroundCollision;

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.name == "Plane") {
            GroundCollision();
        }
    }

    void GroundCollision() {
        if (onGroundCollision != null) {
            onGroundCollision();
        }
    }

}
