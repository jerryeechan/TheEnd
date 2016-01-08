using UnityEngine;
using System.Collections;

public class MiniGameStartEvent : TargetEvent {

	public GameObject miniGame;
	// Use this for initialization
	protected  override void active()
	{
		miniGame.SetActive(true);
		UIManager.instance.hideAllUI();
	}
}
