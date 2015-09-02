using UnityEngine;
using System.Collections;

public class DialogueCharacter : MonoBehaviour {

	// Use this for initialization
	
	Animator anim;
	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	void Start () {
		
	}
	
	enum Expression{Normal,Laugh,Sad};
	Expression expression;
	public void Play(string expression)
	{
		
	}
}
