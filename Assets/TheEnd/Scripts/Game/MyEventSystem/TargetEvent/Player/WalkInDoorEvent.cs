using UnityEngine;
using System.Collections;

public class WalkInDoorEvent : TargetEvent {

	public Door door; 
	// Use this for initialization
	protected override void active()
	{
		float deltax = Player.instance.transform.position.x - transform.position.x;
		Player.instance.setPosition(door.doorWayOut,new Vector2(deltax,0));
	}
}
