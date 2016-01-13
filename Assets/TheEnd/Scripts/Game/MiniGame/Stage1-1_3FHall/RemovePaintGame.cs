using UnityEngine;
using System.Collections;

public class RemovePaintGame : UIPanel {

    BlackPaint[] blackPaints;
    public static RemovePaintGame instance;
	// Use this for initialization
	void Start () {
        instance = this;
	   blackPaints = GetComponentsInChildren<BlackPaint>();
	}
	
	
    
    int removeNum = 0;
    public void removed()
	{
		removeNum++;
		if(removeNum == blackPaints.Length)
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
