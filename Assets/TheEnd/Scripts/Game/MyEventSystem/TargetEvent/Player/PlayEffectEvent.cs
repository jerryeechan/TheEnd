using UnityEngine;
using System.Collections;

public class PlayEffectEvent : TargetEvent {

    public	enum EffectType
    {
        Blood,Health,Hurt
    }
    public EffectType effectType;
    override protected void active()
    {
        switch (effectType)
        {
            case EffectType.Health:
                PlayerEffect.instance.PlayHealthGainEffect();
            break;
            case EffectType.Blood:
                PlayerEffect.instance.PlayHurtEffect();
            break;
            case EffectType.Hurt:
                Player.instance.damaged(20);
            break;
        }
        
    }
}
