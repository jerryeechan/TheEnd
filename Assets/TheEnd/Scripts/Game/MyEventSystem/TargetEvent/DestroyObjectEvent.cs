using UnityEngine;
using System.Collections;

public class DestroyObjectEvent : TargetEvent {

	public GameObject target;
    protected override void active()
    {
        Destroy(target);
    }
}
