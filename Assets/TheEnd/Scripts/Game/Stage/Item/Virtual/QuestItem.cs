using UnityEngine;
using System.Collections;

public class QuestItem : Item {

	// Use this for initialization
	public Quest forQuest;
    
	public string pickUpState;
    public string useState;
	public override void PickedUp()
	{
		base.PickedUp();
		forQuest.current_state = pickUpState;
	}
	
	//give the 
	public override void GiveAway(){
		base.GiveAway();
		
	}
	
	
}
