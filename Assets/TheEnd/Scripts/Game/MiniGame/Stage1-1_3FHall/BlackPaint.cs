using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BlackPaint : MonoBehaviour,IDragHandler {
    Image image;
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.delta.y<0)
        {   
            SoundManager.instance.PlayOneShot("paint_secret");
            image.fillAmount-=0.002f*Math.Abs(eventData.delta.y);
            if(image.fillAmount==0)
            {
                RemovePaintGame.instance.removed();
                gameObject.SetActive(false);
            }
        }
    }

    void Awake()
    {
        image = GetComponent<Image>();
    }
	
}
