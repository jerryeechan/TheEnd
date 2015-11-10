using UnityEngine;
using System.Collections.Generic;


public class ItemPoolManager : Singleton<ItemPoolManager> {

	Dictionary<string,Item> itemDict = new Dictionary<string,Item>();
	void Awake()
	{
		Item [] items =  GetComponentsInChildren<Item>();
		foreach (var item in items)
		{
			itemDict.Add(item.name,item);
		}
	}
	
	public Item getItem(string name)
	{
		if(itemDict.ContainsKey(name))
		return itemDict[name];
		else
		{
			Debug.LogError("Create the item in Item Pool Manager First");
			return null;
		}
	}
}
