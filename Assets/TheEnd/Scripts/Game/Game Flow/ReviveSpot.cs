using UnityEngine;
using System.Collections;

public class ReviveSpot : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider2d)
	{
		if(collider2d.tag == "Player")
		{
			ReviveSpotManager.instance.lastSpot = transform;
		}
	}
}
