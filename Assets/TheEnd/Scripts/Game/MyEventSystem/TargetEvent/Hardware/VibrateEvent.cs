using UnityEngine;
using System.Collections;

public class VibrateEvent : TargetEvent{

	protected override void active()
	{
		if(!conditionValid())
            return;
		#if UNITY_ANDROID
		Handheld.Vibrate();
		#endif
	}
}
