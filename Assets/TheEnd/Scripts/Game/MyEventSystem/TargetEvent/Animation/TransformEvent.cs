using UnityEngine;
using System.Collections;

public class TransformEvent : TargetEvent {

	public Transform target;
	public Vector3 dis;
    public float duration = 1;
	protected override void active()
	{
		LeanTween.move(target.gameObject,target.position+dis,duration).setEase(LeanTweenType.easeOutCubic);
	}
}
