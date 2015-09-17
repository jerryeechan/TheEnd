using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class BaisemaGestureHandler : MonoBehaviour , IPointerDownHandler, IDragHandler, IPointerUpHandler{

	// Use this for initialization

	void Start () {
		
	}
	
	Baisema currentBaisema;
	

	#region IPointerDownHandler implementation

	public void OnPointerDown (PointerEventData eventData)
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint(eventData.position);
		pos.z = 0;
		//currentBaisema = Instantiate(baisemaPrefab,pos,Quaternion.identity) as Baisema;
		//PlayerController.instance.isCastingBaisema = true;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{  
		if (eventData.delta.y>0.6)
		{
			print("swipe up");
            BaisemaManager.instance.swipeUp();
		}
	}
	#endregion
	
	void Update()
	{
        /*
		if(currentState == BaisemaState.Growing)
		{
			if(!currentBaisema.grow())
			{
				currentState = BaisemaState.Fail;
			}
		}
        */
	}
	
	#region IPointerUpHandler implementation

    
	public void OnPointerUp (PointerEventData eventData)
	{
        /*
		if(currentState == BaisemaState.Growing)
		{
			if(!currentBaisema.setUp())
				currentState = BaisemaState.Fail;
			else
				currentState = BaisemaState.Finished;
		}
		
		//PlayerController.instance.isCastingBaisema = false;
        */
	}

	#endregion
		
}
