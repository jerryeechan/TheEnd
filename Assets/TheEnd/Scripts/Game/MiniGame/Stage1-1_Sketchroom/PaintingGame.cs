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
		splashes = GetComponentsInChildren<ColorSplash>();
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
	}
}
