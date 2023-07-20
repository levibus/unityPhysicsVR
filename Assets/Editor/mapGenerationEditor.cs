using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (mapGenerator))]
public class mapGenerationEditor : Editor
{
   public override void OnInspectorGUI() {
        mapGenerator mapGen = (mapGenerator)target;

        if (DrawDefaultInspector()) {
            if (mapGen.autoUpdate) {
                mapGen.GenerateMap();
            }
        }

        if (GUILayout.Button ("Generate")) {
            mapGen.GenerateMap();
        }
   }
}
