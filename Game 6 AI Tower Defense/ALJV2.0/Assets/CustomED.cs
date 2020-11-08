
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BlockState))]
public class CustomED : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BlockState state = (BlockState)target;
        if(GUILayout.Button("Calculate Values"))
        {
            //state.calculateValues();
        }
    }
}
