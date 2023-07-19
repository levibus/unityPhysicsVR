// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class yGravityVector : MonoBehaviour
// {
//     public LayerMask mask;
//     public Transform objectToPlace1;
//     public Transform objectToPlace2;
//     public GameObject cubeHolder;
//     public GameObject yArrowHolder;
//     public GameObject xArrowHolder;
//     public Camera gameCamera;
//     Vector3 nintyDegrees = new Vector3(90.0f, 0.0f, 0.0f);
//     float scaleDown = 0.1f;

//     void Update() {
//         Vector3 screenPos = gameCamera.WorldToScreenPoint(cubeHolder.transform.position);
//         Ray ray = gameCamera.ScreenPointToRay(screenPos);
//         RaycastHit hitInfo;
    
//         if (Physics.Raycast(ray, out hitInfo)) {
//             objectToPlace1.position = hitInfo.point;
//             objectToPlace1.rotation = Quaternion.FromToRotation(Vector3.up, (-1.0f * hitInfo.normal));
//             objectToPlace2.position = hitInfo.point;
//             // objectToPlace2.rotation = objectToPlace1.rotation.eulerAngles + nintyDegrees; find out how to do this with quaternions
//         }

//         scaleArrows();
//     }

//     void scaleArrows() {
//         float angle = objectToPlace1.eulerAngles.y * Mathf.PI / 180f;
//         float scale = 9.81f * Mathf.Sin(angle);
//         float smallerScale = scale * scaleDown;
//         yArrowHolder.transform.localScale = new Vector3(0.25f, scale, 0.25f);

//         xArrowHolder.transform.localScale = new Vector3(0.25f, Mathf.Sqrt(96.2361f - (scale * scale)), 0.25f);
//     }
// }
