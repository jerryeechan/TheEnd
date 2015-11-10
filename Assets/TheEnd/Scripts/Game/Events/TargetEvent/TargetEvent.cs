using UnityEngine;

public interface ITargetEvent{
	void active();
}
public class TargetEvent : MonoBehaviour {

	float delayTime = 0;
	public virtual void triggerEvent()
	{
		if(delayTime!=0)
		Invoke("active",delayTime);
		else
		active();
	}
	protected virtual void active()
	{
		
	}
}