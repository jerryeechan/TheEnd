using UnityEngine;
using System.Collections;

public class PickUpItemEvent : TargetEvent {
	
    public QuestItem item;
    public GameObject pickUpObject;
	protected override void active()
	{	
		//Bag.instance.addItem(GetComponent<ItemTag>().itemName);
        
        UIManager.instance.pickItemView.setContent(item.sprite,item.showname);
        UIManager.instance.pickItemView.Show();
        UIManager.instance.bagView.getItem(item.name);
		Invoke("DestroyObject",0.1f);
	}
	void DestroyObject()
	{
        if(pickUpObject)
        {
            InteractRange.instance.removeFromRange(pickUpObject.GetComponent<InteractableTrigger>());
		    Destroy(pickUpObject);    
        }
		
        
	}
}
