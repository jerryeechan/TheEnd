using UnityEngine;
using System.Collections;

public class OpenDoorEvent : TargetEvent {
    public Door door;
	protected override void active()
	{
         if(!conditionValid())
            return;
        print("door switch");
		door.Switch();
	}
}
