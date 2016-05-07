using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SwitchButton : MonoBehaviour,IPointerClickHandler {
    
    public int index;
    public SwitchableLight controlLight;
    public SpriteRenderer smallBtn;
    static int onNum = 0;
    void Awake()
    {
        image = GetComponent<Image>();
		onNum = 0;
    }
    void Start()
    {

        if(ControlRoomPanel.instance.lightOn[index]==true)
            SwitchOn();
        
        ControlRoomPanel.instance.lightTouched = false;
    }
    Image image;
    bool isOn = false;
    public void Switch()
    {
        if(isOn)
        {
            SwitchOff();
        }
        else
        {
            SwitchOn();
        }
        
    }
	// Use this for initialization
	void SwitchOn()
    {
        print("switch light on"+index.ToString());
        ControlRoomPanel.instance.lightTouched = true;
        if(onNum<3)
        {
            image.sprite = ControlRoomPanel.instance.btnOnSprite;
            smallBtn.sprite = ControlRoomPanel.instance.smallBtnOnSprite;
            controlLight.On();
            isOn = true; 
            ControlRoomPanel.instance.lightOn[index] = true;
            onNum++;
        }
        else
        {
            Player.instance.damaged(20);
            SoundManager.instance.PlayOneShot("electricshock");
        }
    }
    
    void SwitchOff()
    {
        ControlRoomPanel.instance.lightTouched = true;
        image.sprite = ControlRoomPanel.instance.btnOffSprite;
        smallBtn.sprite = ControlRoomPanel.instance.smallBtnOffSprite;
        controlLight.Off();
        isOn = false;
        ControlRoomPanel.instance.lightOn[index] = false;
        onNum--;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Switch();
    }
}
