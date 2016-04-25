using UnityEngine;
using System.Collections;

public class MiniGameStartEvent : TargetEvent {

	public UIPanel miniGameView;
    public string message;
	// Use this for initialization
	protected  override void active()
	{
        if(!conditionValid())
            return;
        print("minigameStart");
		miniGameView.Show();
        miniGameView.SendMessage(message,SendMessageOptions.DontRequireReceiver);
		UIManager.instance.hideControlPanel();
	}
}
