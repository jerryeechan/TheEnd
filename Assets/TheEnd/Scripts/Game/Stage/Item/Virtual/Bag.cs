using System.Collections.Generic;

public class Bag : Singleton<Bag>{

	
	// Use this for initialization
	List<Item> eventItems;
	Dictionary<string,Item> itemDict = new Dictionary<string,Item>();
	public void addItem(string itemName)
	{
		if(itemDict.ContainsKey(itemName))
		{
			itemDict[itemName].num++;
		}
		else{
			Item item = ItemPoolManager.instance.getItem(itemName);
			itemDict.Add(itemName,item);
		}
		itemDict[itemName].PickedUp();
	}
	public void removeItem(Item item)
	{
		eventItems.Remove(item);
	}
	/*
	public Item itemExist(string name)
	{
		if(eventItems.Exists(name))
		return null;
	}*/
}
