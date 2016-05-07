using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ColorSplash : AnimatableGraphic, IPointerEnterHandler
{
	bool hasDrawn = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
		if(hasDrawn == false)
     	{
			 drawColor();
             SoundManager.instance.PlayOneShot("paint_single");
			 hasDrawn = true;
		}
    }

    // Use this for initialization
    void Start()
    {
        //image = GetComponent<Image>();
        graphic.canvasRenderer.SetAlpha(0);
    }
    

    void drawColor()
    {
        graphic.CrossFadeAlpha(1, 1, false);
        PaintingGame.instance.splashDrawn();
    }

}
