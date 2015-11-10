using UnityEngine;
using System.Collections;

public class ItemTag : MonoBehaviour {

	public string itemName;
	public void picked()
	{
		Bag.instance.addItem(itemName);
	}
	
}
