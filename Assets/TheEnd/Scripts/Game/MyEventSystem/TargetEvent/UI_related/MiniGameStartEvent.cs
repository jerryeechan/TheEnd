using UnityEngine;
using System.Collections;

public class MiniGameStartEvent : TargetEvent {

	public MiniGameView miniGame;
	// Use this for initialization
	protected  override void active()
	{
		miniGame.gameObject.SetActive(true);
		UIManager.instance.hideControlPanel();
	}
}
