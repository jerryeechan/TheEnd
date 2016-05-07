using UnityEngine;
using System.Collections;

public class ControlRoomPanel :UIPanel{
    
    
    public Sprite btnOnSprite;
    public Sprite btnOffSprite;
    
    public Sprite smallBtnOnSprite;
    public Sprite smallBtnOffSprite;
    public bool[] lightOn = new bool[9];
    public bool lightTouched = false;
    public static ControlRoomPanel instance;

    override public void Awake()
    {
        base.Awake();
        instance = this; 
    }
	
    public bool checkCorrect()
    {
        if(lightOn[2]==true&&lightOn[3]==true&&lightOn[5]==true)
        {
            return true;
        }
        else
        {
            return false;   
        }
    }
    
    
}
