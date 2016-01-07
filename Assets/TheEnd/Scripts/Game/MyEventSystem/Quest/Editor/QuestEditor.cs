using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        Quest quest = (Quest)target;
        if(GUILayout.Button("Add Quest"))
        {
            quest.addEvent();
        }
    }
}