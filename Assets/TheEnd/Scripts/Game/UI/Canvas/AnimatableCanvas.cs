using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimatableCanvas : MonoBehaviour {
    
    AnimatableGraphic[] graphics;
    public bool includeInChildren = true;
    
	protected virtual void Awake()
	{
        if(includeInChildren)
		graphics = GetComponentsInChildren<AnimatableGraphic>(true);
        else
        graphics = GetComponents<AnimatableGraphic>();
	}
	
	public void hide(float duration)
	{
		foreach(AnimatableGraphic graphic in graphics)
		{
            graphic.hide(duration);
		}
		Invoke("deActivate",1);
	}
	void deActivate()
	{
		gameObject.SetActive(false);
	}
	public void show(float duration)
	{
        activate();
		foreach(AnimatableGraphic graphic in graphics)
		{
            graphic.show(duration);
		}
	}
	void activate()
	{
		gameObject.SetActive(true);
	}
}
