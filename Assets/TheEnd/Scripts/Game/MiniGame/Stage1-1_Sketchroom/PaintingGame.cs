using UnityEngine;
using System.Collections.Generic;

public class PaintingGame : UIPanel {

    public static PaintingGame instance;
	ColorSplash[] splashes;
	int drawnNum;
	
	override protected void Awake()
	{
        instance = this;
        base.Awake();
		splashes = GetComponentsInChildren<ColorSplash>(true);
	}
    override public void Show()
    {
        //base.Show();
        gameObject.SetActive(true);
        GetComponent<AnimatableGraphic>().show(0.5f);
        transform.Find("statuebase").GetComponent<AnimatableGraphic>().show(0.5f);
    } 
	public void splashDrawn()
	{
		print("drawn");
		drawnNum++;
		if(drawnNum == splashes.Length)
		{
			gameDone();	
		}
	}
	
	void gameDone()
	{
		gameObject.SendMessage("Done");
        Invoke("Hide",0.5f);
	}
}
