using UnityEngine;
using System.Collections.Generic;
public class Quest : MonoBehaviour {
	public string questName;
    
	public string[] states;
    public string current_state;
    
    Dictionary<string, QuestEvent> questDict = new Dictionary<string,QuestEvent>();
    void Start()
    {
        
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
}
