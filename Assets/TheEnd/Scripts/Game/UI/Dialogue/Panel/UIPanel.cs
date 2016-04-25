using UnityEngine;
using UnityEngine.UI;
public class UIPanel : AnimatableCanvas {
    public bool isPlaying;
    public float duration = 0.5f;
    
    public void initWithParameter(string parameter)
    {
        
    }
    override public void Awake()
    {
        
        base.Awake();
        
    }
    
    public void Appear()
    {
        isPlaying = true;
        show(0);
        print("appear");
        PlayerController.instance.lockMove(); 
        Player.instance.isInputEnable = false;
    }
	public virtual void Show()
    {
        print("show panel"+name);
        isPlaying = true;
        if(SuperUser.instance)
        {
            if(SuperUser.instance.isSkippingDialogues)
            duration = 0;
            Player.instance.isInputEnable = false;
            Player.instance.lockMove();
                
        }
        show(duration);
        
    }
    
    override protected void showDone()
    {
        base.showDone();
        if(Player.instance)
        {
            Player.instance.isInputEnable = true;
            Player.instance.lockMove();    
        }
        
    }
    public virtual void Hide()
    {
        hide(duration);
        if(Player.instance)
        {
           Player.instance.isInputEnable = false;
           PlayerController.instance.unlockMove();    
        }
        
    }
    
    override protected void hideDone()
    {
        isPlaying = false;
        if(Player.instance!=null)
        {
            Player.instance.isInputEnable = true;
            PlayerController.instance.unlockMove();
        }
        base.hideDone();
    }
    
    
    
}
