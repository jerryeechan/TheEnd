using UnityEngine;
using System.Collections;

public class PickUpItemEvent : TargetEvent {
	
    public QuestItem item;
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
		InteractRange.instance.removeFromRange(GetComponent<InteractableTrigger>());
		Destroy(gameObject.transform.parent.gameObject);
        
	}
}
