using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	
	public Sprite closedSprite;
	public Sprite openedSprite;
	
	Transform blockCollider;
	void Awake()
	{
		blockCollider = transform.Find("collider");
	}
	public void Open()
	{
		GetComponent<SpriteRenderer>().sprite = openedSprite; 
		blockCollider.gameObject.SetActive(false);
	}
}
