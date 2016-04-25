using UnityEngine;
using System.Collections;

public enum WalkInDir{Up,Down};
public class Door : MonoBehaviour {
	
	
	public Sprite closedSprite;
	public Sprite openedSprite;
	
	public Door doorWayOut;
	public WalkInDir walkInDir;
	
	public Collider2D blockCollider;
	void Awake()
	{
		SpriteRenderer spr = GetComponent<SpriteRenderer>();
		if(spr) 
		{
			spr.sprite = closedSprite;
		} 
        if(isOpened)
        {
            GetComponent<SpriteRenderer>().sprite = openedSprite;
		    blockCollider.enabled = false; 
        }
	}
	public bool isOpened = false; 
	public void Switch()
	{
		if(isOpened)
		{
			Close();
		}
		else
		{
			Open();
		}
		isOpened = !isOpened;
	}
	public void Open()
	{
		GetComponent<SpriteRenderer>().sprite = openedSprite;
		SoundManager.instance.PlayOneShot("dooropen");
		blockCollider.enabled = false; 
	}
	
	public void Close()
	{
		GetComponent<SpriteRenderer>().sprite = closedSprite;
		SoundManager.instance.PlayOneShot("doorclose");
		blockCollider.enabled = true; 
	}
}
