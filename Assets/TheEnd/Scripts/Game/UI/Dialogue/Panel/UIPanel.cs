using UnityEngine;
using UnityEngine.UI;
public class UIPanel : AnimatableCanvas {
	public void Show()
    {
        show(0.5f);
        print("show panel");
    }
    public void Hide()
    {
        hide(0.5f);
        print("hide panel");
    }
    
    
    
}
