using UnityEngine;
using System.Collections;

public class ShakeCameraEvent : TargetEvent {
	public float duration;
	protected override void active(){
		iTween.ShakePosition(Camera.main.gameObject,Vector3.one,duration);
	}
	
}
