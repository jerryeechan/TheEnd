using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SkillBtn : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler {
    public void OnDrag(PointerEventData eventData)
    {
       if(eventData.delta.y>6)
        {
            Player.instance.swipeUp();
        }
       else if(eventData.delta.y < -6)
        {
            Player.instance.swipeDown();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Player.instance.skillBtnTouched();
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Player.instance.release();
    }
}
