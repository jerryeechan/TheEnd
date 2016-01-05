using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ColorSplash : MonoBehaviour, IPointerEnterHandler
{

    Image image;
	bool hasDrawn = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
		if(hasDrawn == false)
     	{
			 drawColor();
			 hasDrawn = true;
		}
    }

    // Use this for initialization
    void Awake()
    {
        image = GetComponent<Image>();
        image.canvasRenderer.SetAlpha(0);
    }
    

    void drawColor()
    {
        image.CrossFadeAlpha(1, 1, false);
        PaintingGame.instance.splashDrawn();
    }

}
