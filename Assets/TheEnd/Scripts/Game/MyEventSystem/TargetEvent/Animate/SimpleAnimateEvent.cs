using UnityEngine;
using System.Collections;

public class SimpleAnimateEvent : TargetEvent {


	public SpriteRenderer target;
	public Sprite sprite;
	
	protected override void active()
	{
		if(target==null)
		target = GetComponent<SpriteRenderer>();
		target.sprite = sprite;
	}
}
