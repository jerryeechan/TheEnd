using UnityEngine;
using System.Collections;

public class Item : Collectable {

	bool isUnique = true;
	bool isStackable = true;
	public int num;
	// Use this for initialization
	public virtual void PickedUp()
	{
		
	}
	public virtual void GiveAway(){
		
	}	
}
