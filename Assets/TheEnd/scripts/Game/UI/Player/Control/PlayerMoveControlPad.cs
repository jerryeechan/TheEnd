using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class PlayerMoveControlPad : MonoBehaviour,IDragHandler,IEndDragHandler,IPointerDownHandler,IBeginDragHandler{
	#region IBeginDragHandler implementation
	public GameObject pivot;
	public Transform current;
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

	public Vector2 last_position;
	public Vector2 pivot_position;
	bool isDown = false;
	float th = Mathf.Sin(22.5f*Mathf.PI/180);
	float pivotDis = 6;
	public Vector2 moveVec = Vector2.zero;
	void Update()
	{
		Vector2 v = Vector2.zero;

		pivot_position = Vector2.SmoothDamp(pivot_position,last_position - moveVec*pivotDis, ref v,0.05f);
		pivot.transform.position = pivot_position;
		current.position = last_position;
		
	}
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		Vector2 delta = eventData.position-pivot_position;
		float magnitude = delta.magnitude;
		moveVec = delta.normalized;
		if (moveVec.y > th) {
			moveVec.y = 1;
			//		state = Player.PlayerAnimationState.Walk_Back;
		} else if (moveVec.y < -th) {
			moveVec.y = -1;
			//		state = Player.PlayerAnimationState.Walk_Front;
			
		} else
			moveVec.y = 0;
		
		
		if (moveVec.x > th) {
			moveVec.x = 1;
			//		state = Player.PlayerAnimationState.Walk_Right;
		} else if (moveVec.x < -th) {
			moveVec.x = -1;
			//		state = Player.PlayerAnimationState.Walk_Left;
		} else
			moveVec.x = 0;

		
		moveVec = moveVec.normalized;

		if (magnitude > pivotDis) {


			PlayerController.instance.move (moveVec);

			pivot_position += delta.normalized * eventData.delta.magnitude;

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
		last_position = eventData.position;
		
		
		
		
	}
	#endregion
}
