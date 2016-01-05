using UnityEngine;
using System.Collections.Generic;

public class PaintingGame : Singleton<PaintingGame> {

	ColorSplash[] splashes;
	int drawnNum;
	
	void Awake()
	{
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
		print("Done");
	}
}
