using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour {

	public string dialogueKey;
	public enum DialogueTriggerType{CharacterTrigger,TouchTrigger};
	
	public DialogueTriggerType triggerType;
	
	void OnCollisionEnter2D(Collision2D collision2D)
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D collider2D)
	{
		if(triggerType == DialogueTriggerType.CharacterTrigger)
		{
			DialogueManager.instance.PlayDialogue(dialogueKey);
		}
	}
	
	void OnTouchBegan()
	{
		if(triggerType == DialogueTriggerType.TouchTrigger)
		{
			DialogueManager.instance.PlayDialogue(dialogueKey);
		}
	}
}
