using UnityEngine;
using System.Collections;

public class WalkInDoorEvent : TargetEvent {

	public Door door; 
    public bool isUpDown = true;
	// Use this for initialization
	protected override void active()
	{
        if(isUpDown)
        {
            float deltax = Player.instance.transform.position.x - transform.position.x;
		    Player.instance.setPosition(door.doorWayOut,new Vector2(deltax,0));    
        }
        else
        {
            float deltay = Player.instance.transform.position.y - transform.position.y;
		    Player.instance.setPosition(door.doorWayOut,new Vector2(0,deltay));
        }
		
	}
}
