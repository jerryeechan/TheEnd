using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimatableCanvas : MonoBehaviour {
    
    AnimatableGraphic[] graphics;
    public bool includeInChildren = true;
    public bool isAnimating = false;
	public virtual void Awake()
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
            isAnimating = true;
            if(graphics!=null)
            {
                foreach(AnimatableGraphic graphic in graphics)
                {
                    graphic.hide(duration);
                }
            }
            if(duration == 0)
                hideDone();
            else
                Invoke("hideDone",duration);
            
        }
        else{
            Debug.LogError("Fuck animating");
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
            isAnimating = true;
            activate();
            foreach(AnimatableGraphic graphic in graphics)
            {
                graphic.show(duration);
            }
            print(duration);
            if (duration == 0)
                showDone();
            else
                Invoke("showDone",duration);
         
        }
	}
    
	protected virtual void activate()
	{
		gameObject.SetActive(true);
	}
    
    protected virtual void showDone()
    {
        isAnimating = false;
        print("showDone"+name);
    }
}
