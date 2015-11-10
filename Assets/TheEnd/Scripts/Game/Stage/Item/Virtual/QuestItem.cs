using UnityEngine;
using System.Collections;

public class QuestItem : Item {

	// Use this for initialization
	public string [] carriedStates;
	
	public override void PickedUp()
	{
		base.PickedUp();
		PlayerState.instance.eventStateList.AddRange(carriedStates);
	}
	
	//give the 
	public override void GiveAway(){
		base.GiveAway();
		foreach (var state in carriedStates)
		{
			PlayerState.instance.eventStateList.Remove(state);	
		}
		
	}
	
	
}
