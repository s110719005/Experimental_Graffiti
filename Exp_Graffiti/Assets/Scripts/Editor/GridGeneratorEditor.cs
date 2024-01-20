using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GridSystem;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        

        serializedObject.Update();

        DrawInspector();

        GridGenerator gridGenerator = target as GridGenerator;

        if (GUILayout.Button("Add empty grid into Scene"))
        {
            gridGenerator.DEBUG_GenerateGrid();
        }           
        if (GUILayout.Button("Add empty grid using grid SO"))
        {
            gridGenerator.DEBUG_GenerateGridTemplate();
        }           
        if (GUILayout.Button("Record grid color into SO"))
        {
            gridGenerator.DEBUG_RecordColor();

        }  
        if (GUILayout.Button("Reset Grid"))
        {
            gridGenerator.DEBUG_ResetGrid();
        }           

        serializedObject.ApplyModifiedProperties();

        SceneView.RepaintAll();
    }

        

    private void DrawInspector()
    {
        EditorGUILayout.LabelField("Grid Generator", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        GUILayout.BeginVertical();
        {
            var gridDefinition = serializedObject.FindProperty("gridDefinition");
            EditorGUILayout.PropertyField(gridDefinition);
            var DEBUG_hasGenerate = serializedObject.FindProperty("DEBUG_hasGenerate");
            EditorGUILayout.PropertyField(DEBUG_hasGenerate);
        }
        GUILayout.EndVertical();


    }
}


