using UnityEngine;
public class PlayDialogueEvent : MonoBehaviour,ITargetEvent {
	public string id;
	
	
	public void active()
	{
		DialogueManager.instance.PlayDialogue(id);
	}
}
