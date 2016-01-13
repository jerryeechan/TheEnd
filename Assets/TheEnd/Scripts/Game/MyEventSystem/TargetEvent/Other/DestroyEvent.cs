using UnityEngine;
using System.Collections;

public class DestroyEvent : TargetEvent {

	public GameObject target;
    protected override void active()
    {
        Destroy(target);
    }
}
