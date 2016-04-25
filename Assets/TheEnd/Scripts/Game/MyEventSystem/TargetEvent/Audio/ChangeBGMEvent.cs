using UnityEngine;
using System.Collections;

public class ChangeBGMEvent : TargetEvent {

	public string bgmName;
    protected override void active()
    {
        SoundManager.instance.ChangeBGM(bgmName);
    }
}
