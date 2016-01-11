using UnityEngine;
using System.Collections;

public class MiniGameCompleteEvent : TargetEvent {

	protected override void active()
	{
        //wrong 
		transform.parent.parent.gameObject.SetActive(false);	
		UIManager.instance.showControlPanel();
	}
}
