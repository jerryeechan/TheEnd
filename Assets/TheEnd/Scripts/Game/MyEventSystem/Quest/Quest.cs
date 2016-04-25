using UnityEngine;
using System.Collections.Generic;
public class Quest : MonoBehaviour {
    public static Quest currentQuest;
	public string questName;
    
	public string[] states;
    public string current_state = "start";
    
    Dictionary<string, QuestEvent> questDict = new Dictionary<string,QuestEvent>();
    
    void Start()
    {
        QuestEvent[] questEvents = GetComponentsInChildren<QuestEvent>();
        foreach(QuestEvent questEvent in questEvents)
        {
            if(questDict.ContainsKey(states[questEvent.require_state_id]))
            {
                Debug.LogError(states[questEvent.require_state_id]);
                Debug.LogError(gameObject.transform.parent.name);
                Debug.LogError(gameObject.name);
            }
            else{
                questDict.Add(states[questEvent.require_state_id],questEvent);    
            }
            
        }
    }
    public bool triggered(string with_state)
    {
        string temp_state = current_state;
        if(with_state!="")
        {
            temp_state = with_state;
        }
        
        if(questDict.ContainsKey(temp_state))
        {
            questDict[temp_state].triggerEvents();  
            current_state = temp_state;
            return true;
        }
        else
        {
//           Debug.LogError("No mach Quest event state");
           return false;
        }
    }
    public static void broadcast(string with_state)
    {
        if(currentQuest)
            currentQuest.triggered(with_state);
    }
    public void changeState(int id)
    {
        current_state = states[id];
    }
    public void removeQuestEvent(int require_state_id)
    {
        questDict.Remove(states[require_state_id]);
    }
}
