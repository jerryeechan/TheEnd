using UnityEngine;
using System.Collections;

public class MapTrigger :GameTrigger {

	void OnTriggerEnter2D(Collider2D collider2D)
	{
		activeTriggerEvent();
	}
}
