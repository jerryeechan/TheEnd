public class PlayDialogueEvent : TargetEvent {
	public string id;
	
	public override void active()
	{
		DialogueManager.instance.PlayDialogue(id);
	}
}
