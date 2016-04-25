using UnityEngine;
using TheEnd;
public class PlayConditionDialogueEvent : TargetEvent {
	public string id;
    public MainCharacterEnum ch;
    
	public bool showOption = true;
	protected override void active()
	{
        if(!conditionValid())
            return;
        if(ch == Player.instance.current_ch)
        {
            DialogueManager.instance.eventTriggerBy = this;
		    DialogueManager.instance.PlayDialogue(id,showOption);    
        }
	}
}
