using UnityEngine;
using System.Collections;

public class OpenDoorEvent : TargetEvent {
	protected override void active()
	{
		GetComponent<Door>().Switch();
	}
}
