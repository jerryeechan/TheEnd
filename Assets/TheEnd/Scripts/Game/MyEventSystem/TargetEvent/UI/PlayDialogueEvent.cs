using UnityEngine;
public class PlayDialogueEvent : TargetEvent {
	public string id;
	
	protected override void active()
	{
		DialogueManager.instance.eventTriggerBy = this;
		DialogueManager.instance.PlayDialogue(id);
		
	}
}
