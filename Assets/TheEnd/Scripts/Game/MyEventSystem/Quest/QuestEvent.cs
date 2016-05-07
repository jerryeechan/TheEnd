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
    public bool once = false;
    //public string require_state;
    //public string goto_state;
	void Awake()
    {
        events = GetComponentsInChildren<TargetEvent>();
        quest = GetComponentInParent<Quest>();
    }
    
    public void triggerEvents()
    {
        Quest.currentQuest = quest;
        print(Quest.currentQuest);
        
        
        Invoke("changeState",changeState_delay);
            
        foreach (var targetEvent in events)
        {
            targetEvent.triggerEvent();	
        }
        
        if(once)
        {
           quest.removeQuestEvent(require_state_id);
        }
    }
    void changeState()
    {
        print("changeState");
        print(goto_state_id);
        quest.changeState(goto_state_id);
        print(quest.current_state);
    }
}
