using UnityEngine;
using System.Collections;

public class SetPositionEvent : TargetEvent {

	public Transform to;
	public Transform forTarget;
	protected override void active ()
	{
		forTarget.position = to.position;
	}
}
