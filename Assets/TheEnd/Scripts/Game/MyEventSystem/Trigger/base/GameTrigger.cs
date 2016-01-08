using UnityEngine;

public enum TriggerTargetType{Quest,Event};
[ExecuteInEditMode]
public class GameTrigger : MonoBehaviour {

    public TriggerTargetType targetType;
	TargetEvent[] targetEvents;
	public Quest[] quests;
    public string with_state = "";
    //public string goto_state;
	protected virtual void Awake(){
		switch(targetType)
        {
            case TriggerTargetType.Event:
                targetEvents = GetComponentsInChildren<TargetEvent>();
            break;
            case TriggerTargetType.Quest:
            break;
        }
	}
	public bool once;
	public bool isEnabled = true;
	
	
	//trigger the target events binded
	public virtual void triggerEvent()
	{
		if(isEnabled)
		{
            switch(targetType)
            {
                case TriggerTargetType.Event:
                    foreach (var targetEvent in targetEvents)
                    {
                        targetEvent.triggerEvent();	
                    }
                    break;
                case TriggerTargetType.Quest:
                    quests[0].triggered(with_state);
                break;
            }
			
			
			
			if(once == true)
			{
				Destroy(this);
			}
				
		}
		
	}

   
}

/*
using UnityEngine;


public class GameTrigger : MonoBehaviour {

	public TargetEvent[] targetEvents;
	public State [] requiredStates;
	public Quest quest;
	// Use this for initialization
	protected virtual void Awake(){
		
	}
	public bool once;
	public bool isEnabled = true;
	
	
	//trigger the target events binded
	public virtual void triggerEvent()
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
			{
				Destroy(this);
			}
				
		}
		
	}

   
}


*/