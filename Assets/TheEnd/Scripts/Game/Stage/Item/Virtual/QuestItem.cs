using UnityEngine;
using System.Collections;

public class QuestItem : Item {

	// Use this for initialization
    
    public string showname;
    public string description;
    public string useState;
    
	public override void PickedUp()
	{
		base.PickedUp();
		//forQuest.current_state = pickUpState;
	}
	
	//give the 
	public override void GiveAway(){
		base.GiveAway();
		
	}
	public void changeState(string state,string description)
    {
        this.useState = state;
        if(description!="")
        this.description = description;
    }
	
}
