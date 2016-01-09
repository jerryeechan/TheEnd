using UnityEngine;
using System.Collections.Generic;

public class SoundManager : Singleton<SoundManager> {

	public AudioClip [] clips;
	Dictionary<string,AudioClip> clipDict = new Dictionary<string,AudioClip>(); 
	public AudioSource audioSource;
	void Awake()
	{
		foreach (var clip in clips)
		{
			if(clip)
			{
				clipDict.Add(clip.name,clip);	
			}
				
		}
		
		audioSource = GetComponent<AudioSource>();
	}
	public void PlaySound(string name)
	{
		AudioClip clip = clipDict[name];
		audioSource.clip = clip;
		audioSource.Play();
	}
	public void StopSound()
	{
		audioSource.Stop();
	}
	public void PlayOneShot(string name)
	{
		AudioClip clip = clipDict[name];
		
		audioSource.PlayOneShot(clip,1);
	}
}
