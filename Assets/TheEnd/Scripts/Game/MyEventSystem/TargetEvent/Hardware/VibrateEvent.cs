using UnityEngine;
using System.Collections;

public class VibrateEvent : TargetEvent{

	protected override void active()
	{
		
		#if UNITY_ANDROID
		Handheld.Vibrate();
		#endif
	}
}
