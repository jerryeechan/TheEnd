using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class GroundTouchHandler : MonoBehaviour , IPointerDownHandler, IDragHandler, IPointerUpHandler{

	// Use this for initialization
	public Baisema baisemaPrefab;
	void Start () {
		
	}
	
	Baisema currentBaisema;
	
	enum BaisemaState
	{
		None,
		Growing,
		Fail,
		Finished
	}
	BaisemaState currentState = BaisemaState.None;

	#region IPointerDownHandler implementation

	public void OnPointerDown (PointerEventData eventData)
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint(eventData.position);
		pos.z = 0;
		currentBaisema = Instantiate(baisemaPrefab,pos,Quaternion.identity) as Baisema;
		currentState = BaisemaState.Growing;
		PlayerController.instance.isCastingBaisema = true;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		if(currentState == BaisemaState.Growing)
		{
			if(!currentBaisema.grow())
			{
				currentState = BaisemaState.Fail;
			}
			if (eventData.delta.y>0.6)
			{
				print("swipe up");
				BaisemaManager.instance.explodeAll();
			}
		}
	}
	#endregion
	
	void Update()
	{
		if(currentState == BaisemaState.Growing)
		{
			if(!currentBaisema.grow())
			{
				currentState = BaisemaState.Fail;
			}
		}
	}
	
	#region IPointerUpHandler implementation

	public void OnPointerUp (PointerEventData eventData)
	{
		if(currentState == BaisemaState.Growing)
		{
			if(!currentBaisema.setUp())
				currentState = BaisemaState.Fail;
			else
				currentState = BaisemaState.Finished;
		}
		
		PlayerController.instance.isCastingBaisema = false;
	}

	#endregion
	
	void OnTouchBegan(TouchInfo touchInfo)
	{
		print("touch began");
		currentBaisema = Instantiate(baisemaPrefab,touchInfo.touchPos,Quaternion.identity) as Baisema;
		currentState = BaisemaState.Growing;
		PlayerController.instance.isCastingBaisema = true;
	}
	void OnTouchMoved(TouchInfo touchInfo)
	{
		if(currentState == BaisemaState.Growing)
		{
			if(!currentBaisema.grow())
			{
				currentState = BaisemaState.Fail;
			}
			if (touchInfo.deltaPosition.y>0.6)
			{
				print("swipe up");
				BaisemaManager.instance.explodeAll();
			}
		}
	}
	void OnTouchStay(TouchInfo touchInfo)
	{
		if(currentState == BaisemaState.Growing)
		{
			if(!currentBaisema.grow())
			{
				currentState = BaisemaState.Fail;
			}
		}
	}
	void OnTouchEnded(TouchInfo touchInfo)
	{
		if(currentState == BaisemaState.Growing)
		{
			if(!currentBaisema.setUp())
				currentState = BaisemaState.Fail;
			else
				currentState = BaisemaState.Finished;
		}
		
		PlayerController.instance.isCastingBaisema = false;
		
	}
}
