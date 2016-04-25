using UnityEngine;

public interface ITargetEvent{
	void active();
}
public class TargetEvent : MonoBehaviour {

	public float delayTime = 0;
	public virtual void triggerEvent()
	{
        if(conditionValid())
        {
            if(delayTime!=0)
            Invoke("active",delayTime);
            else
            active();    
        }
	}
	protected virtual void active()
	{
        
	}
    public bool conditionValid()
    {
        EventCondition[] conditions = GetComponents<EventCondition>();
		foreach(EventCondition condition in conditions)
        {
            if(!condition.checkValid())
            {
                return false;
            }
        }
        return true;
    }
}