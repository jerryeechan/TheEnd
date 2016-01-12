using UnityEngine;
using System.Collections;

public class ChangeQuestItemStateEvent : TargetEvent {

    public QuestItem item;
    public string state;
	// Use this for initialization
	override protected void active()
    {
        item.useState = state;
    }
}
