using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestEvent))]
public class QuestEditor : Editor
{
    
    int require_state_id;
    int goto_state_id;
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawDefaultInspector();
        QuestEvent questEvent = target as QuestEvent;
        SerializedProperty tps = serializedObject.FindProperty("quest");
        Quest q = tps.objectReferenceValue as Quest;
        
     //   SerializedObject qs = new UnityEditor.SerializedObject(q);
        
        
        EditorGUI.BeginChangeCheck();
        questEvent.require_state_id = EditorGUILayout.Popup(questEvent.require_state_id,q.states);
        //questEvent.require_state = q.states[require_state_id];
        
        questEvent.goto_state_id = EditorGUILayout.Popup(questEvent.goto_state_id,q.states);
        //questEvent.goto_state = q.states[goto_state_id];
        
        //EditorGUILayout.PropertyField(qs.FindProperty("states"),true);
        
        if(EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
        
    }
    
}