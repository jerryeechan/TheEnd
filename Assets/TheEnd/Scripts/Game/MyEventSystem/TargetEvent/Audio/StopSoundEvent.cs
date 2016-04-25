using UnityEngine;
using System.Collections;

public class StopSoundEvent : TargetEvent {

	public string clipName;
	public SoundPlayer player;
	protected override void active()
	{
		SoundManager.instance.StopSound(clipName);
	}
}
