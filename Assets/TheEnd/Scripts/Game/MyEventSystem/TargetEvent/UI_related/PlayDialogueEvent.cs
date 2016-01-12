using UnityEngine;
public class PlayDialogueEvent : TargetEvent {
	public string id;
	public bool showOption = false;
	protected override void active()
	{
		DialogueManager.instance.eventTriggerBy = this;
		DialogueManager.instance.PlayDialogue(id,showOption);
		
	}
}
