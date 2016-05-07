using UnityEngine;
using System.Collections;

public class PlaySoundEvent : TargetEvent {
	public string clipName;
	public AudioClip clip;
	public bool oneshot = true;

	protected override void active()
	{
        if(!conditionValid())
            return;
        
			if(oneshot == true)
	        {
				if(clip)
				{
					SoundManager.instance.PlayOneShot(clip);	
				}
				else
	            SoundManager.instance.PlayOneShot(clipName);
	        }
	        else
	        {
	            SoundManager.instance.PlaySound(clipName);
	        }	
        
        	
	}
}
