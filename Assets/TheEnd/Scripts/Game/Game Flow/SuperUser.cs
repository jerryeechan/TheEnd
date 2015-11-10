using UnityEngine;
using System.Collections;

public class SuperUser : Singleton<SuperUser> {

	public bool isActive;
	
	public bool isSkippingDialogues;
	public float su_speed = 1;
	// Use this for initialization
	void Awake () {
		if(isSkippingDialogues)
			Debug.LogError("skip dialogues!!");
		su_speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
