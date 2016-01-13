﻿using UnityEngine;
using System.Collections;

public class PlaySoundEvent : TargetEvent {
	public string clipName;
	public bool oneshot = true;
	protected override void active()
	{
			if(oneshot == true)
			{
				SoundManager.instance.PlayOneShot(clipName);
			}
			else
			{
				SoundManager.instance.PlaySound(clipName);
			}	
		
		
	}
}
