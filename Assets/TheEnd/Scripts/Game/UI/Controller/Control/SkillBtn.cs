using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
public class SkillBtn : Singleton<SkillBtn>,IPointerDownHandler,IDragHandler,IPointerUpHandler {
    public Sprite baisemaImage;
    public Sprite investigateImage;
    
    Image image;
    void Awake()
    {
        image = GetComponent<Image>();
    }
    public enum SkillBtnMode{
        Baisema,Investigate
    }
    SkillBtnMode currentMode = SkillBtnMode.Baisema;
    public void changeMode(SkillBtnMode mode)
    {
        if(currentMode != mode)
        {
           switch(mode)
            {
                case SkillBtnMode.Baisema:
                    image.sprite = baisemaImage;
                    break;
                case SkillBtnMode.Investigate:
                    image.sprite = investigateImage;
                    break;
            } 
            currentMode = mode;
        }
        
    }
    public void OnDrag(PointerEventData eventData)
    {
       if(eventData.delta.y>6)
        {
            Player.instance.swipeUp();
        }
       else if(eventData.delta.y < -6)
        {
            Player.instance.setMoveVec(Vector2.zero);
            Player.instance.swipeDown();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Touched");
        Player.instance.setMoveVec(Vector2.zero);
        Player.instance.skillBtnTouched();
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Player.instance.release();
    }
}
