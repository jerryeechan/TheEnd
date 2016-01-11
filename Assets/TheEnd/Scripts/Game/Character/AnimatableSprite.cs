using UnityEngine;
using System.Collections;

public class AnimatableSprite : MonoBehaviour {

    public void moveTo(Vector3 dis,float duration)
    {
        LeanTween.move(gameObject,dis,duration);
    }
    
    public void flipDir()
    {
        Vector3 v =  gameObject.transform.localScale;
        v.x *= -1;
        gameObject.transform.localScale = v;
    }
    
    public void setAlpha(float value,float duration)
    {
        SpriteRenderer[] sprs = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer spr in sprs)
        LeanTween.alpha(spr.gameObject,value,duration);
    }
}
