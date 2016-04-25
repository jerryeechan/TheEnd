using UnityEngine;
using System.Collections;

public class ControlRoomLightTurnedCondition : EventCondition {

	public override bool checkValid()  
    {
        return base.checkValid()^ControlRoomPanel.instance.checkCorrect();
    }
}
