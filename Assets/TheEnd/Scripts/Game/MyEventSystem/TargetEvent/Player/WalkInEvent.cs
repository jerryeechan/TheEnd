using UnityEngine;
using System.Collections;
using TheEnd;
public class WalkInEvent : TargetEvent {
    
	public Door door; 
    public CharacterAnimationState turnToState;
    
	// Use this for initialization
	protected override void active()
	{
        switch (turnToState)
        {
            case CharacterAnimationState.Stand_Front:
                float deltax = Player.instance.transform.position.x - transform.position.x;
		        Player.instance.setPosition(door.doorWayOut,new Vector2(deltax,-1));    
            break;
            
        }
        Player.instance.PlayAnimation(turnToState);
        
		
	}
}
