using UnityEngine;
using System.Collections;

public class LittleGameStartEvent : TargetEvent {

	public GameObject littlegame;
	// Use this for initialization
	protected  override void active()
	{
		littlegame.SetActive(true);
		UIManager.instance.hideAllUI();
	}
}
