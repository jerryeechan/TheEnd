using UnityEngine;
using UnityEngine.UI;
public class UIPanel : AnimatableCanvas {
	public void Show()
    {
        show(1);
        print("show panel");
    }
    public void Hide()
    {
        hide(1);
        print("hide panel");
    }
    
    
    
}
