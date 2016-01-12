using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class BagView : UIPanel {

	ItemView[] itemViews;
	Dictionary<string,ItemView> itemViewDict = new Dictionary<string,ItemView>();
	public Transform arrowPivot;
	public Text descriptionText;
    
	QuestItem selectedItem;
	 
	override protected void Awake()
	{
        print("Bag activate");
		base.Awake();
		itemViews = GetComponentsInChildren<ItemView>(true);
		foreach(ItemView itemView in itemViews)
		{
            if(itemView.item)
			{
                print(itemView.item.name);
                itemViewDict.Add(itemView.item.name,itemView);
            }
		}
        transform.Find("slot").gameObject.SetActive(false);
	}
    void Start()
    {
        gameObject.SetActive(false);
    }
    override public void Show()
    {
        print("Bag show");
        base.Show();
        foreach(ItemView itemView in itemViews)
		{
			if(itemView.has==false)
            {
                itemView.gameObject.SetActive(false);
            }
		}
    }
    override public void Hide()
    {
        base.Hide();
        Quest.currentQuest = null;
    }
	public void selectItem(string itemName)
	{
        foreach(KeyValuePair<string, ItemView> entry in itemViewDict)
        {
            ItemView itemView = entry.Value;
            
            if(itemView.item.name == itemName)
            {
    //			print(itemView.itemName);
                itemView.selected();
                selectedItem = itemView.item;
                LeanTween.rotateZ(arrowPivot.gameObject,itemView.degree,0.5f).setEase(LeanTweenType.easeInOutCubic);
                print(itemView.degree);
                print(itemView.item.name);
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
        
        print("getItem:"+itemName);
		itemViewDict[itemName].getItem();
	}
	public void removeItem()
	{
	
	}
    
    
    public void useItem()
    {
        if(!Quest.currentQuest.triggered(selectedItem.useState))
        {
            DialogueManager.instance.PlayDialogue("noeffect",false);
        }
        Quest.currentQuest = null;
        Hide();
    }
    
}
