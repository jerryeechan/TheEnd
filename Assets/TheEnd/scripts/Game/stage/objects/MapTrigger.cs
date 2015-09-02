using UnityEngine;
using System.Collections;

public class MapTrigger : MonoBehaviour {

	// Use this for initialization
	public enum TriggerType{
		LevelCleared
	}
	public TriggerType triggerType;
	
	void OnTriggerEnter2D(Collider2D collider2D)
	{
		
	}
	
	void activeTriggerEvent()
	{
		switch(triggerType)
		{
		
		}
	}
}
