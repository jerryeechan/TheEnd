using UnityEngine;
using System.Collections;

public class GoToLevelEvent : TargetEvent {

	public int level;
	override protected void active()
	{
		Application.LoadLevel(level);
	}
}
