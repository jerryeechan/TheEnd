using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PickItemView : UIPanel{

	public Text text;
    public Image image;
    public void setContent(Sprite sprite,string text)
    {
        this.image.sprite = sprite;
        this.text.text = "獲得 "+text;
    }
}
