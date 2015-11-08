using UnityEngine;
using UnityEngine.UI;

public class DialogueInvestigationPanel : UIPanel {

	// Use this for initialization
	public DialogueInvestigateImageManager ivImageManager;
	public Image picture_hori;
	public Image picture_vert;
	
	
	// Update is called once per frame
	public void setPicture(string image)
	{
		if(image =="pic6")
		{
			picture_vert.gameObject.SetActive(true);
			picture_hori.gameObject.SetActive(false);
			
			picture_vert.sprite = ivImageManager.getImage(image);
		}
			
		else 
		{
			picture_vert.gameObject.SetActive(false);
			picture_hori.gameObject.SetActive(true);
			
			picture_hori.sprite = ivImageManager.getImage(image);
		}
			
	}
	
	
}
