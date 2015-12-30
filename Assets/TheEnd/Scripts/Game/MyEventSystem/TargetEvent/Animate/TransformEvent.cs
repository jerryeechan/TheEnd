using UnityEngine;
using System.Collections;

public class TransformEvent : TargetEvent {

	public Transform target;
	public  Vector3 dis;
	protected override void active()
	{
		LeanTween.move(target.gameObject,target.position+dis,1);
	}
}
