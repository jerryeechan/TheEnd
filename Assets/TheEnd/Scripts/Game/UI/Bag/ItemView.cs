using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemView : MonoBehaviour,IPointerClickHandler {
	public Image image;
	public Image halo;
	public string itemName;
	public int degree;
	public string itemDescription;
	
	void Awake()
	{
		image = GetComponent<Image>();
//		halo.canvasRenderer.SetAlpha(0);
		image.canvasRenderer.SetAlpha(0);
		getItem();
	}
	
	
	public bool has = false;
	
	public void getItem()
	{
		has = true;
		image.canvasRenderer.SetAlpha(1);
	}
		
	public void selected()
	{
		//halo.CrossFadeAlpha(1,0.5f,false); //Animate alpha to 1
		print("selected");
	}
	public void deselected()
	{
		//halo.CrossFadeAlpha(0,0.5f,false); //Animate alpha to 0
		print("deselected");
	}

    public void OnPointerClick(PointerEventData eventData)
    {
		print("pointer click"+itemName);
     	BagView.instance.selectItem(itemName);
    }
}
