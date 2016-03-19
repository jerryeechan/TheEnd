using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemView : MonoBehaviour,IPointerClickHandler {
	public Image image;
    
    public QuestItem item; 
    
    
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
	bool isSelected = false;
	public void getItem()
	{
		has = true;
		image.canvasRenderer.SetAlpha(1);
	}
		
	public void selected()
	{
        isSelected = true;
        LeanTween.scale(gameObject,Vector3.one*1.2f,0.5f);
		//halo.CrossFadeAlpha(1,0.5f,false); //Animate alpha to 1
	}
	public void deselected()
	{
        if(isSelected)
        {
            LeanTween.scale(gameObject,Vector3.one,0.5f);
            isSelected = false;
        }
        
		//halo.CrossFadeAlpha(0,0.5f,false); //Animate alpha to 0
	//	print("deselected");
	}

    public void OnPointerClick(PointerEventData eventData)
    {
     	UIManager.instance.bagView.selectItem(item.name);
    }
}
