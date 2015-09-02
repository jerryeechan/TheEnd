using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//[ExecuteInEditMode]
public class IsometricSprite : MonoBehaviour {

	// Use this for initialization
	
	
	List<SpriteRenderer> sprs;
	List<int> localSortingOrders;
	Transform myTransform;
	bool hasInited = false;
	
	void Start () {
		if(!hasInited)
		{
			sprs = new List<SpriteRenderer>();
			localSortingOrders = new List<int>();
			SpriteRenderer[] sprArray=  GetComponentsInChildren<SpriteRenderer>();
			for(int i=0;i<sprArray.Length;i++)
			{
				sprs.Add(sprArray[i]);
				//original sorting order??/
				localSortingOrders.Add(sprArray[i].sortingOrder);
			}
			
			myTransform = transform;
			hasInited = true;
		}
		
	}
	
	void setOrder()
	{
		for(int i=0;i<sprs.Count;i++)
		{
			//sprs[i].sortingOrder = localSortingOrders[i]- Mathf.RoundToInt(myTransform.position.y*200);
			sprs[i].sortingOrder = - Mathf.RoundToInt(myTransform.position.y*200);
		}
		
	}
	// Update is called once per frame
	void Update () {
		setOrder();
	}
}

