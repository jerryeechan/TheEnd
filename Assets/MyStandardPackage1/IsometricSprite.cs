using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[ExecuteInEditMode]
public class IsometricSprite : MonoBehaviour {

	// Use this for initialization
	
	
	List<SpriteRenderer> sprs;
	List<int> localSortingOrders;
	Transform myTransform;
	bool hasInited = false;
    
    
	
	void Awake () {
        
		if(!hasInited)
		{
			sprs = new List<SpriteRenderer>();
			localSortingOrders = new List<int>();
			
            IsometricComponent[] ics = GetComponentsInChildren<IsometricComponent>();
			for(int i=0;i<ics.Length;i++)
			{
                
				sprs.Add(ics[i].GetComponent<SpriteRenderer>());
				//original sorting order??/
				localSortingOrders.Add(ics[i].localorder);
			}
			
			myTransform = transform;
			hasInited = true;
            setOrder();
		}
		
	}
	
	protected void setOrder()
	{
		for(int i=0;i<sprs.Count;i++)
		{
			sprs[i].sortingOrder = localSortingOrders[i] - Mathf.RoundToInt(myTransform.position.y*200);
			//sprs[i].sortingOrder = - (Mathf.RoundToInt(myTransform.position.y*200) - Mathf.RoundToInt(sprs[i].transform.position.y));
            
		}
		
	}

	
}

