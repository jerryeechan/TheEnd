using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimatableCanvas : MonoBehaviour {

	Image[] images;
	Text[] texts;
	protected virtual void Awake()
	{
		images = GetComponentsInChildren<Image>();
		texts = GetComponentsInChildren<Text>();
		
	}
	
	public void hide(float duration)
	{
		foreach(Image image in images)
		{
			image.CrossFadeAlpha(0,duration,false);
		}
		
		foreach(Text text in texts)
		{
			text.CrossFadeAlpha(0,duration,false);
		}
		Invoke("deActivate",2);
	}
	void deActivate()
	{
		gameObject.SetActive(false);
		show(1);
	}
	public void show(float duration)
	{
		activate();
		foreach(Image image in images)
		{
			image.CrossFadeAlpha(1,duration,false);
		}
		foreach(Text text in texts)
		{
			text.CrossFadeAlpha(1,duration,false);
		}
	}
	void activate()
	{
		gameObject.SetActive(true);
		foreach(Image image in images)
		{
			image.canvasRenderer.SetAlpha(0);
		}
		foreach(Text text in texts)
		{
			text.canvasRenderer.SetAlpha(0);
		}
	}
}
