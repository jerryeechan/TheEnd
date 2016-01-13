using UnityEngine;
using System.Collections;

public class ChangeQuestItemStateEvent : TargetEvent {

    public QuestItem item;
    public string state;
    public string description;
	// Use this for initialization
	override protected void active()
    {
        item.changeState(state,description);
    }
}
