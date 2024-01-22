using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GridSystem;


[CustomEditor(typeof(GridDefinition))]
public class GridDefinitionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        

        serializedObject.Update();

        DrawInspector();

        
        if (GUILayout.Button("Save"))
        {
            AssetDatabase.SaveAssets();
            Undo.RecordObject(target, "Setting Value");
            EditorUtility.SetDirty(target);
        }           

        serializedObject.ApplyModifiedProperties();

        SceneView.RepaintAll();
    }

        

    private void DrawInspector()
    {
        EditorGUILayout.LabelField("Grid Definition", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        GUILayout.BeginVertical();
        {
            var gridWidth = serializedObject.FindProperty("gridWidth");
            EditorGUILayout.PropertyField(gridWidth);
            var gridHeight = serializedObject.FindProperty("gridHeight");
            EditorGUILayout.PropertyField(gridHeight);
            var cellSize = serializedObject.FindProperty("cellSize");
            EditorGUILayout.PropertyField(cellSize);
            var gridSprite = serializedObject.FindProperty("gridSprite");
            EditorGUILayout.PropertyField(gridSprite);
            var templateSprite = serializedObject.FindProperty("templateSprite");
            EditorGUILayout.PropertyField(templateSprite);
            var usedColors = serializedObject.FindProperty("usedColors");
            EditorGUILayout.PropertyField(usedColors);
            var gridColorDatas = serializedObject.FindProperty("gridColorDatas");
            EditorGUILayout.PropertyField(gridColorDatas);
        }
        GUILayout.EndVertical();
        


    }
}
