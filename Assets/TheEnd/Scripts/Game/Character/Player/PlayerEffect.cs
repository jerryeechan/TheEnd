using UnityEngine;
using System.Collections;

public class PlayerEffect : Singleton<PlayerEffect> {

    public ParticleSystem healthGain;
	// Use this for initialization
    public BloodSplash hurtEffect;
    
	void Start () {
	    //PlayHealthGainEffect();
	}
	
	// Update is called once per frame
	public void PlayHealthGainEffect()
    {
        healthGain.Emit(10);
    }
    public void PlayHurtEffect()
    {
        hurtEffect.splash(1);
    }
}
