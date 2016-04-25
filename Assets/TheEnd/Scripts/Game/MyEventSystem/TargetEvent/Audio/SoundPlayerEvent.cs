using UnityEngine;
using System.Collections;

public class SoundPlayerEvent : TargetEvent {
	public AudioClip clip;
	public SoundPlayer player;

	public bool oneshot = false;
	public bool play = true;
	protected override void active()
	{
        if(!conditionValid())
            return;
        if(play == true)
        {
			if(oneshot == true)
	        {
	            player.PlayOneShot(clip);
	        }
	        else
	        {
			player.PlaySound(clip);
	        }	
        }
		else
		{
		player.StopSound(clip);
		}
        	
	}
}
