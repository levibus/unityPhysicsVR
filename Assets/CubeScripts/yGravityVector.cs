using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yGravityVector : MonoBehaviour
{
    public LayerMask mask;
    public Transform objectToPlace;
    public GameObject cubeHolder;
    public GameObject arrowHolder;
    public Camera gameCamera;
    float scaleDown = 0.1f;

    void Update() {
        Vector3 screenPos = gameCamera.WorldToScreenPoint(cubeHolder.transform.position);
        Ray ray = gameCamera.ScreenPointToRay(screenPos);
        RaycastHit hitInfo;
    
        if (Physics.Raycast(ray, out hitInfo)) {
            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, (-1.0f * hitInfo.normal));
        }

        scaleArrow();
    }

    void scaleArrow() {
        float angle = objectToPlace.eulerAngles.y * Mathf.PI / 180f;
        float scale = 9.81f * Mathf.Sin(angle) * scaleDown;
        arrowHolder.transform.localScale = new Vector3(0.25f, scale, 0.25f);
    }
}
