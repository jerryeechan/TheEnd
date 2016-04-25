using UnityEngine;
public class PlayDialogueEvent : TargetEvent {
	public string id;
	public bool showOption = true;
	protected override void active()
	{
        if(!conditionValid())
        return;
		DialogueManager.instance.eventTriggerBy = this;
        print(DialogueManager.instance.eventTriggerBy);
		DialogueManager.instance.PlayDialogue(id,showOption);
		
	}
}
