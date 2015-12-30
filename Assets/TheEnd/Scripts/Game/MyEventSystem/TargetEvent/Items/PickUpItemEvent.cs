using UnityEngine;
using System.Collections;

public class PickUpItemEvent : TargetEvent {
	
	protected override void active()
	{	
		Bag.instance.addItem(GetComponent<ItemTag>().itemName);
		Invoke("DestroyObject",0.1f);
	}
	void DestroyObject()
	{
		InteractRange.instance.removeFromRange(GetComponent<InteractableTrigger>());
		Destroy(gameObject);
	}
}
