using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static Player instance;
	Animator anim;
	void Awake()
	{
		instance = this;
		anim = GetComponentInChildren<Animator>();
		lastState = PlayerAnimationState.Stand_Front;
	}
	
	void OnCollisionEnter2D(Collision2D collision2d)
	{
		Collider2D collider2D = collision2d.collider;
		switch(collision2d.collider.tag)
		{
			case "Enemy":
				Enemy enemy = collider2D.GetComponent<Enemy>();
				
				break;
			case "Item":
			break;
		}
		
	}
	
	PlayerAnimationState lastState;
	public enum PlayerAnimationState{None,Walk_Front,Stand_Front,Walk_Left,Stand_Left,Walk_Right,Stand_Right,Walk_Back,Stand_Back};
	public void PlayAnimation(PlayerAnimationState state)
	{
		
		if(state == PlayerAnimationState.None)
		{
			switch(lastState)
			{
				case PlayerAnimationState.Walk_Back:
				state = PlayerAnimationState.Stand_Back;break;
				case PlayerAnimationState.Walk_Front:
				state = PlayerAnimationState.Stand_Front;break;
			}
		}
		else
		{
		
		}
		//anim.Play(name);
		lastState = state;
	}
}
