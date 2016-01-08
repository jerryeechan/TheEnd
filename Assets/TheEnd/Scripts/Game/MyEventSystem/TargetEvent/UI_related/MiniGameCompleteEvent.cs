using UnityEngine;
using System.Collections;

public class MiniGameCompleteEvent : TargetEvent {

	protected override void active()
	{
		transform.parent.parent.gameObject.SetActive(false);	
		UIManager.instance.hideAllUI();
	}
}
