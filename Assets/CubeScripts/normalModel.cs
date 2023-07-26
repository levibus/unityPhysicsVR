// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;

// public class normalModel1 : MonoBehaviour
// {
//     public event Action onArrowPlacement;

//     public GameObject normalSnap;
//     public GameObject arrowModel;
//     public GameObject testCube;
//     public GameObject testCube2;
//     public GameObject testCube3;
//     public GameObject testCube4;
//     public GameObject cube;
//     float spacing2 = 0.5f;
//     bool active = false;

//     normalArrowChange normalChange;

//     void Start() {
//         arrowModel.SetActive(false);
//         testCube.SetActive(false);
//         testCube2.SetActive(false);
//         testCube3.SetActive(false);
//         testCube4.SetActive(false);

//         normalChange = FindObjectOfType<normalArrowChange>();
//         normalChange.onArrowDestruction += creation;
//     }
    
//     void Update() {
//        // lerp back to start position
//         if (active && arrowModel.transform.position.x < cube.transform.position.x + spacing2 && arrowModel.transform.position.y < cube.transform.position.y + spacing2 && arrowModel.transform.position.z < cube.transform.position.z + spacing2 && 
//             arrowModel.transform.position.x > cube.transform.position.x - spacing2 && arrowModel.transform.position.y > cube.transform.position.y - spacing2 && arrowModel.transform.position.z > cube.transform.position.z - spacing2) {
//             ArrowPlacement();
//             active = false;
//             arrowModel.SetActive(false);
//             testCube.SetActive(true);
//         }
//     }

//     void creation() {
//         arrowModel.SetActive(true);
//         transform.position = normalSnap.transform.position;
//         arrowModel.transform.eulerAngles = Vector3.up;
//         active = true;
//     }

//     void ArrowPlacement() {
//         if(onArrowPlacement != null) {
//             testCube2.SetActive(true);
//             onArrowPlacement();
//              testCube3.SetActive(true);
//         }
//          testCube4.SetActive(true);
//     }
// }