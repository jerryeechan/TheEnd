using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemView : MonoBehaviour,IPointerClickHandler {
	public Image image;
    
    public QuestItem item; 
	public int degree;
    
    
	void Awake()
    {
        image = GetComponent<Image>();
        
    }
	void Start()
	{
		//gameObject.SetActive(false);
//		halo.canvasRenderer.SetAlpha(0);
		//getItem();
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
	}
	public void deselected()
	{
		//halo.CrossFadeAlpha(0,0.5f,false); //Animate alpha to 0
	//	print("deselected");
	}

    public void OnPointerClick(PointerEventData eventData)
    {
     	UIManager.instance.bagView.selectItem(item.name);
    }
}
