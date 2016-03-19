using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RemovePaintGame : UIPanel {

    BlackPaint[] blackPaints;
    public static RemovePaintGame instance;
    public Sprite realPaintSprite;
    public MiniGameHint hint;
	// Use this for initialization
    Image paintingImage;
	void Start () {
       instance = this;
	   blackPaints = GetComponentsInChildren<BlackPaint>();
       finishNum = blackPaints.Length;
       paintingImage = transform.Find("frame").Find("painting").GetComponent<Image>();
       Invoke("checkProgress",2);
	}
    
    override protected void showDone()
    {
        base.showDone();
        paintingImage.sprite = realPaintSprite;
    }
    
	void checkProgress()
    {
        if(removeNum<1)
        {
            hint.showHint();
        }
    }
	int finishNum;
    
    int removeNum = 0;
    public void removed()
	{
		removeNum++;
		if(removeNum == finishNum)
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
