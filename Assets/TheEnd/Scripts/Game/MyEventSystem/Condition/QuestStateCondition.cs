using UnityEngine;
using System.Collections;

public class QuestStateCondition : EventCondition {
    public Quest quest;
	// Use this for initialization
	public string[] states;
    
    public override bool checkValid()
    {
        foreach(string state in states)
        {
            if(!(validWhenTrue^(quest.current_state == state))==true)
            {
                return true;
            }
        }
        return false;
    }
}
