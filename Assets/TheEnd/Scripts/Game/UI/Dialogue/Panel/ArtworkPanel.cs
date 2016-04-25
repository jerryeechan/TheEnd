using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ArtworkPanel : UIPanel {
    
    public Artwork[] artworks;
    public Image left;
    public Text leftText;
    public Image right;
    public Text rightText;
    int currentAt = 0;
    public override void Awake()
    {
        base.Awake();
        setContent(0);
    }
    public void switchPage(int dir)
    {
        if(dir>0)
        {
            if(currentAt+2<=artworks.Length-2)
            {
                currentAt+=2;
            }
            else
            {
                return;
            }
        }
        else
        {
            if(currentAt-2>=0)
            {
                currentAt-=2;
            }
            else
            {
                return;
            }
        }
        setContent(currentAt);
        
    }
	
	void setContent(int index)
    {
        left.sprite = artworks[index].sp;
        left.SetNativeSize();
        right.sprite = artworks[index+1].sp;
        right.SetNativeSize();
        leftText.text = artworks[index].description;
        rightText.text = artworks[index+1].description;
    }
}
