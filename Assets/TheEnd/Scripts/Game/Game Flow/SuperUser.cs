using UnityEngine;
using System.Collections;

public class SuperUser : Singleton<SuperUser> {

	public bool isActive;
	
	public bool isSkippingDialogues;
	// Use this for initialization
	void Awake () {
		if(isSkippingDialogues)
			Debug.LogError("skip dialogues!!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
