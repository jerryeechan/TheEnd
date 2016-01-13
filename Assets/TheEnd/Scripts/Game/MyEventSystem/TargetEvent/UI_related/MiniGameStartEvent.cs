using UnityEngine;
using System.Collections;

public class MiniGameStartEvent : TargetEvent {

	public UIPanel miniGameView;
	// Use this for initialization
	protected  override void active()
	{
		miniGameView.Show();
		UIManager.instance.hideControlPanel();
	}
}
