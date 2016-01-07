using UnityEngine;
using System.Collections;

public class FinishedTrigger : GameTrigger {
    public void Done()
    {
        print("FinishedTrigger done");
        triggerEvent();
    }
	
}
