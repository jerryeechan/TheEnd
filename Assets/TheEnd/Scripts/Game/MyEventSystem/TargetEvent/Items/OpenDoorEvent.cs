using UnityEngine;
using System.Collections;

public class OpenDoorEvent : TargetEvent {
    public Door door;
	protected override void active()
	{
        print("door switch");
		door.Switch();
	}
}
