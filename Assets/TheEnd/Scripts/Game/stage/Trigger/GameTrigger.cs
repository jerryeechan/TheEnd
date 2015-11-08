using UnityEngine;


public class GameTrigger : MonoBehaviour {

	// Use this for initialization
	protected virtual void Awake(){
		
	}
	public bool once;
	public bool isEnabled = true;
	public void activeTriggerEvent()
	{
		if(isEnabled)
		{
			GetComponent<ITargetEvent>().active();
			if(once == true)
				Destroy(gameObject);	
		}
		
	}

   
}
