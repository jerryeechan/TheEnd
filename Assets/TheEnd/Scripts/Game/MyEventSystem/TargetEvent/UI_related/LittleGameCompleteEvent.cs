using UnityEngine;
using System.Collections;

public class LittleGameCompleteEvent : TargetEvent {

	protected override void active()
	{
		transform.parent.parent.gameObject.SetActive(false);	
		UIManager.instance.hideAllUI();
	}
}
