using UnityEngine;
using System.Collections;

public class HealCube : AnimatableSprite {
    
    public int amount = 30;
	void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag=="Player")
        {
            Player.instance.recover(amount);
            setAlpha(0,1);
            Invoke("Recycle",1f);
        }
    }
    void Recycle()
    {
        Destroy(gameObject);
    }
}
