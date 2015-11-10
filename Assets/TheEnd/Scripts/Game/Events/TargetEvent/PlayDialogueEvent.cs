using UnityEngine;
public class PlayDialogueEvent : TargetEvent {
	public string id;
	
	protected override void active()
	{
		DialogueManager.instance.PlayDialogue(id);
	}
}
