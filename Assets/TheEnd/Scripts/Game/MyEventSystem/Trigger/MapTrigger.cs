using UnityEngine;
using System.Collections;

public class MapTrigger :GameTrigger {

	void OnTriggerEnter2D(Collider2D collider2D)
	{
        print("Ontriggered");
        print(collider2D.name);
		if(collider2D.tag == "Player")
		{
            triggerEvent();
        }
	}
}
