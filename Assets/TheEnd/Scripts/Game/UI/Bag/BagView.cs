using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class BagView : UIPanel {

	ItemView[] itemViews;
	Dictionary<string,ItemView> itemViewDict = new Dictionary<string,ItemView>();
	public Transform arrowPivot;
	public Text descriptionText;
	
	 
	override protected void Awake()
	{
		base.Awake();
		itemViews = GetComponentsInChildren<ItemView>();
		foreach(ItemView itemView in itemViews)
		{
			itemViewDict[itemView.itemName] = itemView;
		}
		
		
	}
	public void selectItem(string itemName)
	{
        foreach(KeyValuePair<string, ItemView> entry in itemViewDict)
        {
            ItemView itemView = entry.Value;
            
            if(itemView.itemName == itemName)
            {
    //			print(itemView.itemName);
                itemView.selected();
                LeanTween.rotateZ(arrowPivot.gameObject,itemView.degree,0.5f).setEase(LeanTweenType.easeInOutCubic);
                print(itemView.degree);
                print(itemView.itemName);
                descriptionText.text = itemView.itemDescription;
                //arrowPivot.
            }
            else
            {
    //			print(itemView.itemName);
                itemView.deselected();
            }
        }
	}
	
	public void getItem(string itemName)
	{
		itemViewDict[itemName].getItem();
	}
	public void removeItem()
	{
	
	}
    
    
    public void useItem()
    {
        
    }
    
    public void closeBag() 
    {
        hide(1);
    }
}
