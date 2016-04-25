using UnityEngine;
using System.Collections;

public class TransformEvent : TargetEvent {

	public Transform target;
	public Vector3 dis;
    public float duration = 1;
	protected override void active()
	{
        if(!conditionValid())
            return;
		LeanTween.move(target.gameObject,target.position+dis,duration).setEase(LeanTweenType.easeOutCubic);
	}
}
