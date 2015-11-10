using UnityEngine;
using System.Collections;

public class PlaySoundEvent : TargetEvent {
	public string clipName;
	protected override void active()
	{
		SoundManager.instance.PlayOneShot(clipName);
	}
}
