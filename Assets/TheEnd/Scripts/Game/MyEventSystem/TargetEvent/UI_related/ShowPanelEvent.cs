using UnityEngine;
using System.Collections;

public class ShowPanelEvent : TargetEvent{
    
    public UIPanel panel;
	override protected void active()
    {
        panel.Show();
    }
}
