using UnityEngine;
using System.Collections.Generic;

public class SoundPlayer: MonoBehaviour {

	 
	public AudioSource[] audioSources;
	public AudioClip autoPlay;

	void Awake()
	{
		if(autoPlay)
			PlaySound(autoPlay);
	}

    Dictionary<AudioClip,AudioSource> clipAudioDict = new Dictionary<AudioClip,AudioSource>();
	public void PlaySound(AudioClip clip)
	{
		AudioSource a = audioSources[0];
        a.Stop();
        a.clip = clip;
		a.Play();
		clipAudioDict[clip] = a;
        
	}
	public void StopSound(AudioClip clip)
	{
        clipAudioDict[clip].Stop();
        clipAudioDict[clip] = null;
	}
	public void PlayOneShot(AudioClip clip)
	{
		AudioSource a = audioSources[0];
		a.PlayOneShot(clip,1);
	}
}
