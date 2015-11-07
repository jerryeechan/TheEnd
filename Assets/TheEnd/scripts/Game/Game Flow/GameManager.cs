using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameTrigger startTrigger;
	void Start()
	{
		startTrigger.activeTriggerEvent();	
	}
	
}
