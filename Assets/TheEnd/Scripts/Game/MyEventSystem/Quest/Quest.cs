using UnityEngine;
using System.Collections.Generic;
public class Quest : MonoBehaviour {
	public string questName;
    
	public string[] states;
    public string current_state = "start";
    
    Dictionary<string, QuestEvent> questDict = new Dictionary<string,QuestEvent>();
    
    void Start()
    {
        QuestEvent[] questEvents = GetComponentsInChildren<QuestEvent>();
        foreach(QuestEvent questEvent in questEvents)
        {
            if( questDict.ContainsKey(states[questEvent.require_state_id]))
            {
                Debug.LogError(states[questEvent.require_state_id]);
                Debug.LogError(gameObject.name);
            }
            else{
                questDict.Add(states[questEvent.require_state_id],questEvent);    
            }
            
        }
    }
    public void triggered(string with_state)
    {
        if(with_state!="")
        {
            current_state = with_state;    
        }
        QuestEvent target;
        if(target = questDict[current_state])
        {
           target.triggerEvents();
        }
        else
        {
           Debug.LogError("No mach Quest event state");
        }
    }
    public void changeState(int id)
    {
        current_state = states[id];
    }
}
