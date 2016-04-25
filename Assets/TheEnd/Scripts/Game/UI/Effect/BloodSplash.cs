using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BloodSplash :AnimatableCanvas {

    public AnimatableGraphic[] graphics;
    
    
    
    void Start()
    {
            
    }
    public float totalDuration;
    public void splash()
    {
        isAnimating = true;
        gameObject.SetActive(true);
        foreach(AnimatableGraphic graphic in graphics)
        {
            
            graphic.setAlpha(0);
            graphic.showDefault();
            Invoke("splashDone",totalDuration);
        }
        /*
        blood1.show(0.5f);
        blood2.show(0.5f,0.5f);
        blood3.show(0.5f,1f);
        bg.show(1f);
        dead.show(1f,1.2f);
        */
    }
    public void splashDone()
    {
        isAnimating = false;
    }
    public void splash(float recoverDelay)
    {
        splash();
        print("splash");
        Invoke("recover",recoverDelay);
    }
    public void recover()
    {
        foreach(AnimatableGraphic graphic in graphics)
        {
            graphic.hide();
        }
    }
    
    
}
