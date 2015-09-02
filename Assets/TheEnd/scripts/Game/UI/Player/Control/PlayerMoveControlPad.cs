using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class PlayerMoveControlPad : MonoBehaviour,IDragHandler,IEndDragHandler,IPointerDownHandler,IBeginDragHandler{
	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		isDown = true;
		last_position = eventData.position;
		pivot_position = eventData.position;
	}

	#endregion

	#region IPointerDownHandler implementation

	public void OnPointerDown (PointerEventData eventData)
	{
		
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		isDown = false;
		PlayerController.instance.move (Vector2.zero);
	}

	#endregion

	Vector2 last_position;
	Vector2 pivot_position;
	bool isDown = false;
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		Vector2 delta = eventData.position-pivot_position;
		float magnitude = delta.magnitude;
		if(magnitude>4)
		{
			PlayerController.instance.move(delta.normalized);
			pivot_position += eventData.delta;
		}
		
		
		
		/*
		if(Input.touchCount > 0)
		{
			delta = Input.GetTouch(0);
			//print(delta.normalized);
		}
		else
		{
			
			float pointer_x = Input.GetAxis("Mouse X");
			float pointer_y = Input.GetAxis("Mouse Y");
			delta = new Vector2(pointer_x,pointer_y);
			
		}
		*/
		
		//PlayerController.instance.move(delta.normalized);
		//last_position = eventData.position;
		
		
		
		
	}
	#endregion
}
