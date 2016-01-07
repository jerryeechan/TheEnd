using UnityEngine;
using System.Collections;

public class ShowOptionEvent : TargetEvent {

	public QuestItem optionItem1;
	public QuestItem optionItem2;
	// Use this for initialization
	protected override void active()
	{
		bool hasItem1 = PlayerState.instance.checkState(optionItem1.carriedStates[0]);
		bool hasItem2 = PlayerState.instance.checkState(optionItem2.carriedStates[0]);
		
		if(hasItem1&&hasItem2)
		OptionPanel.instance.ShowOption(optionItem1,optionItem2);
		else if(hasItem1)
		OptionPanel.instance.ShowOption(optionItem1);
		else if(hasItem2)
		OptionPanel.instance.ShowOption(optionItem2);
	}
}
