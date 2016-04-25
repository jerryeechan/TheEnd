using UnityEngine;
using System.Collections;

public class ShowPanelEvent : TargetEvent{
    
    public UIPanel panel;
    public string parameter;
	override protected void active()
    {
        if(!conditionValid())
            return;
        panel.Show();
        panel.initWithParameter(parameter);
    }
}
