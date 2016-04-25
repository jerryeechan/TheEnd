using UnityEngine;
using System.Collections.Generic;

public class SoundManager : Singleton<SoundManager> {

	public AudioClip [] clips;
	Dictionary<string,AudioClip> clipDict = new Dictionary<string,AudioClip>(); 
	public AudioSource[] audioSources;
    public AudioSource BGM;
	void Awake()
	{
		foreach (var clip in clips)
		{
			if(clip)
			{
				clipDict.Add(clip.name,clip);	
			}
				
		}
		
		audioSources = GetComponents<AudioSource>();
	}
    AudioSource emptyAudioSource()
    {
        foreach(AudioSource a in audioSources)
        {
           if(!a.isPlaying)
            return a;
        }
        return audioSources[0];
    }
    Dictionary<string,AudioSource> clipAudioDict = new Dictionary<string,AudioSource>();
	public void PlaySound(string name)
	{
        print("sound:"+name);
		AudioClip clip = clipDict[name];
        AudioSource a = emptyAudioSource();
        a.clip = clip;
		a.Play();
        clipAudioDict[name] = a;
        
	}
	public void StopSound(string name)
	{
		if(clipAudioDict.ContainsKey(name))
		{
			clipAudioDict[name].Stop();
        	clipAudioDict[name] = null;	
		}
        
	}
	public void PlayOneShot(string name)
	{
        print("sound");
		AudioClip clip = clipDict[name];
		AudioSource a = emptyAudioSource();
		a.PlayOneShot(clip,1);
	}
    public void ChangeBGM(string name)
    {
        BGM.clip = clipDict[name];
        BGM.Play();
    }
}
