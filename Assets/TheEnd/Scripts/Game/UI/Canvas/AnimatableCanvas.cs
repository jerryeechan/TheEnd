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
    
    protected void loadGraphics()
    {
        if(includeInChildren)
		  graphics = GetComponentsInChildren<AnimatableGraphic>(true);
        else
          graphics = GetComponents<AnimatableGraphic>();
    }
	
	public void hide(float duration)
	{
        if(graphics!=null)
        {
            foreach(AnimatableGraphic graphic in graphics)
            {
                graphic.hide(duration);
            }
        }
        Invoke("hideDone",duration);
	}
	protected virtual void hideDone()
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
        Invoke("showDone",duration);
	}
    
	protected virtual void activate()
	{
		gameObject.SetActive(true);
	}
    
    protected virtual void showDone()
    {
        
    }
}
