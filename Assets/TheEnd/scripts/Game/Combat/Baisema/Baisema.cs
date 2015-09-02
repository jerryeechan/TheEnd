using UnityEngine;
using System.Collections;

public class Baisema : MonoBehaviour {

	// Use this for initialization
	
	public GameObject growingBorder;
	public GameObject baisemaObject;
	public GameObject perfectArea;
	
	Vector3 growingScale = Vector3.zero;
	void Awake() {
		//growingBorder = transform.Find("growingBorder").gameObject;
		//baisemaObject = transform.Find("baisemaObject").gameObject;
		//perfectArea = transform.Find("perfectArea").gameObject;
		//growingBorder.SetActive(false);
		//perfectArea.SetActive(false);
		
		baisemaObject.SetActive(false);
	}
	
	public bool grow()
	{
		growingScale += new Vector3(0.02f,0.02f);
		growingBorder.transform.localScale = growingScale;
		if (growingBorder.transform.localScale.x > 1.2)
		{
			fail ();
			return false;
		}
		return true;
	}
	
	//set the baisema up with concrete collider
	public bool setUp()
	{
		if(growingScale.x <0.9f)
		{
			fail ();
			return false;
		}
		else
		{
			growingBorder.SetActive(false);
			perfectArea.SetActive(false);
			baisemaObject.SetActive(true);
			Invoke("setUpDone",0.2f);
			BaisemaManager.instance.addBaisema(this);
			return true;
		}
		
	}
	public void setUpDone()
	{
		baisemaObject.GetComponent<Collider2D>().isTrigger = false;
	}
	
	//destroy the baiesma to attack the monster trap inside
	public void explode()
	{
		baisemaObject.SetActive(false);
	}
	
	void fail()
	{
		destroy();
	}
	void destroy()
	{
		Destroy(gameObject);
	}
}
