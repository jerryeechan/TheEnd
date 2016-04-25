using UnityEngine;
using System.Collections;

public class SelectDollEvent : TargetEvent {

    public Transform target;
	protected override void active ()
	{
        SelectDoll.instance.SelectTo(target);
    }
}
