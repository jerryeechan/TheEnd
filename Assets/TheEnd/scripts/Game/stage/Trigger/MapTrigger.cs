using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MapTrigger : MonoBehaviour {

	// Use this for initialization
	public enum TriggerType{
		LevelCleared,
        PlayDialugue
	}

	public TriggerType triggerType;
    
	public string value;

	void OnTriggerEnter2D(Collider2D collider2D)
	{
		
	}
	


	public void activeTriggerEvent()
	{
		switch(triggerType)
        {
            case TriggerType.PlayDialugue:
                DialogueManager.instance.PlayDialogue(value);
                break;
        }
	}

   
}
