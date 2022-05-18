using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MazeGenerator))]
public class MazeGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //base.OnInspectorGUI();
        MazeGenerator mz = (MazeGenerator)target;
        if (GUILayout.Button("Build Maze"))
        {
            mz.Generate();
        }
    }
}