using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class QuestEvent : MonoBehaviour {
   
	// Use this for initialization
    public Quest quest;
    TargetEvent[] events;
    
    public int require_state_id;
    public int goto_state_id;
    
    public float changeState_delay = 0;
    //public string require_state;
    //public string goto_state;
	void Awake()
    {
        events = GetComponentsInChildren<TargetEvent>();
        quest = GetComponentInParent<Quest>();
    }
    
    public void triggerEvents()
    {
        foreach (var targetEvent in events)
        {
            targetEvent.triggerEvent();	
        }
        Invoke("changeState",changeState_delay);
    }
    void changeState()
    {
        quest.changeState(goto_state_id);
    }
}
