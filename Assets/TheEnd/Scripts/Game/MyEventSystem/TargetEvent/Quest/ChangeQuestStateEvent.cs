using UnityEngine;
using System.Collections;

public class ChangeQuestStateEvent : TargetEvent {

	public Quest quest;
    public string state;
    override protected void active()
    {
        quest.current_state = state;
    } 
}
