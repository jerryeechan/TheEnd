using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimatableGraphic : MonoBehaviour {
    MaskableGraphic graphic;
    public float showAlpha = 1;
	// Use this for initialization
	void Awake()
    {
        graphic = GetComponent<MaskableGraphic>();
        setAlpha(0);
    }
    public void setAlpha(float alpha)
    {
        graphic.canvasRenderer.SetAlpha(alpha);
    }
    public void show(float duration)
    {
        //print(gameObject.name);
        if(graphic)
        {
            gameObject.SetActive(true);
            setAlpha(0);
            graphic.CrossFadeAlpha(showAlpha,duration,false);
        }
        
    }
    public void hide(float duration)
    {
        if(graphic)
        graphic.CrossFadeAlpha(0,duration,false);
    }
}
