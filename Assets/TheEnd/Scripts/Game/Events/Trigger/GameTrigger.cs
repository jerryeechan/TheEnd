using UnityEngine;


public class GameTrigger : MonoBehaviour {

	public TargetEvent[] targetEvents;
	public string requiredState = "none";
	// Use this for initialization
	protected virtual void Awake(){
		
	}
	public bool once;
	public bool isEnabled = true;
	
	
	//trigger the target events binded
	public void triggerEvent()
	{
		if(isEnabled)
		{
			if(targetEvents.Length==0)
			{
				targetEvents = GetComponents<TargetEvent>();
			}
			foreach (var targetEvent in targetEvents)
			{
				targetEvent.triggerEvent();	
			}
			
			if(once == true)
				Destroy(this);	
		}
		
	}

   
}
