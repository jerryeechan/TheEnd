using UnityEngine;
using System.Collections;

public class EventCondition : MonoBehaviour {

    public bool validWhenTrue = true;
	// Use this for initialization
	public virtual bool checkValid()
    {
        return validWhenTrue;
    }
}
