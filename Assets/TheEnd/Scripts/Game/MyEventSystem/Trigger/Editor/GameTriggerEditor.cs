using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameTrigger),true)]
public class GameTriggerEditor : Editor
{
    /*
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawDefaultInspector();
        GameTrigger gameTrigger = target as GameTrigger;
        
        
     //   SerializedObject qs = new UnityEditor.SerializedObject(q);
        
        
        EditorGUI.BeginChangeCheck();
        gameTrigger.targetType = (TriggerTargetType)EditorGUILayout.EnumPopup(gameTrigger.targetType);
        
        switch(gameTrigger.targetType)
        {
            case TriggerTargetType.Event:
                EditorGUILayout.ObjectField(gameTrigger.targetEvents, typeof(TargetEvent[]));
                break;
            case TriggerTargetType.Quest:
            break; 
        }
        //questEvent.require_state = q.states[require_state_id];
        
        //questEvent.goto_state = q.states[goto_state_id];
        
        //EditorGUILayout.PropertyField(qs.FindProperty("states"),true);
        
        if(EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
        
    }
    */
}