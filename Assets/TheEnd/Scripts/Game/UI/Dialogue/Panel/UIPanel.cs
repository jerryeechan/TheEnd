using UnityEngine;
using UnityEngine.UI;
public class UIPanel : AnimatableCanvas {
    public bool isPlaying;
    static float duration = 0.5f;
	public virtual void Show()
    {
        isPlaying = true;
        show(duration);
        print("show panel");
        Player.instance.isInputEnable = false;
    }
    
    override protected void showDone()
    {
        base.showDone();
        Player.instance.isInputEnable = true;
    }
    public virtual void Hide()
    {
        hide(duration);
        print("hide panel");
        Player.instance.isInputEnable = false;
    }
    
    override protected void hideDone()
    {
        isPlaying = false;
        Player.instance.isInputEnable = true;
        base.hideDone();
    }
    
    
    
}
