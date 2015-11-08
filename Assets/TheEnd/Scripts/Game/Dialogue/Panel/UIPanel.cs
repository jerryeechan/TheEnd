using UnityEngine;

public class UIPanel : MonoBehaviour {
	Animator anim;
	void Awake()
	{
		
	}
	public void Show()
	{
		anim = GetComponent<Animator>();
		Debug.Log(anim);
		anim.Play("show");
	}
	public void Hide()
	{
		anim = GetComponent<Animator>();
		anim.Play("hide");
	}
}
