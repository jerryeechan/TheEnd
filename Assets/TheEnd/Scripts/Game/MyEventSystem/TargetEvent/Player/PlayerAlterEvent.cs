using UnityEngine;
using System.Collections;

public class PlayerAlterEvent : TargetEvent {

    public string todo;
	protected override void active()
	{
		switch(todo)
        {
            case "canUseSkill":
                Player.instance.canUseSkill = true;
            break;    
            default:
                Debug.LogError("No such todo:"+todo);
            break;
        }
		
	}
}
