using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimatableCanvas : MonoBehaviour {
    
    AnimatableGraphic[] graphics;
    public bool includeInChildren = true;
    bool isAnimating = false;
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
        if(!isAnimating)
        {
            if(graphics!=null)
            {
                foreach(AnimatableGraphic graphic in graphics)
                {
                    graphic.hide(duration);
                }
            }
            Invoke("hideDone",duration);
            isAnimating = true;
        }
	}
	protected virtual void hideDone()
	{
        isAnimating = false;
		gameObject.SetActive(false);
	}
	public void show(float duration)
	{
        if(!isAnimating)
        {
            activate();
            foreach(AnimatableGraphic graphic in graphics)
            {
                graphic.show(duration);
            }
            Invoke("showDone",duration);
            isAnimating = true;
        }
	}
    
	protected virtual void activate()
	{
		gameObject.SetActive(true);
	}
    
    protected virtual void showDone()
    {
        isAnimating = false;
    }
}
