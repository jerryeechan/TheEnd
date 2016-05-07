using UnityEngine;
using System.Collections;

public class SwitchableLight : MonoBehaviour,ISwitchable {
    
    
    
    Light controlLight;
    SpriteRenderer spr;
    void Awake()
    {
        controlLight = GetComponentInChildren<Light>();
        spr = GetComponent<SpriteRenderer>();
        if(name!="Light0"&&name!="Light1"&&name!="Light_hint_hair")
        Off();
    }
    
    public void On()
    {
        // controlLight.intensity = 5.7f;
        controlLight.enabled = true;
        if(spr)
        {
            spr.enabled = true;
            
        }
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void Off()
    {
        // controlLight.intensity = 0;
        controlLight.enabled = false;
        if(spr)
        {
            spr.enabled = false;
            
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
