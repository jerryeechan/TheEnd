using UnityEngine;
using System.Collections;

public class LightCorrectCondition : EventCondition {

	public override bool checkValid()  
    {
        return !(base.checkValid()^ControlRoomPanel.instance.checkCorrect());
    } 
}
