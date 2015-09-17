using UnityEngine;
using System.Collections.Generic;

public class DialogueCharacter : MonoBehaviour {

    // Use this for initialization

    //Animator anim;
    SpriteRenderer spr;
    public List<Sprite> expressions;
    Dictionary<string, int> expressionDict;
	void Awake()
	{
        //anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        expressionDict = new Dictionary<string, int>();
	}
	void Start () {
		
	}
	
	enum Expression{Normal,Laugh,Sad};

	Expression expression;
	public void Play(string expression)
	{
        
        //anim.Play(expression);
	}
}
