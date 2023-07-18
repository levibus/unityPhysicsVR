using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalArrow : MonoBehaviour
{
    public LayerMask mask;
    public Transform normalVector;
    public Transform xGravityVector;
    public Transform yGravityVector;
    public GameObject cubeHolder;
    public Camera gameCamera;

    void Update() {
        Vector3 screenPos = gameCamera.WorldToScreenPoint(cubeHolder.transform.position);
        Ray ray = gameCamera.ScreenPointToRay(screenPos);
        RaycastHit hitInfo;
    
        if (Physics.Raycast(ray, out hitInfo)) {
            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }
}
