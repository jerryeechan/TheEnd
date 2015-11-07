using UnityEngine;
using System.Collections.Generic;

namespace TheEnd
{
	public enum MainCharacterEnum {none,moshiue,riddle,ziching};
	public enum Expression{none,angry,ordinary,sad,shocked,smile,worried};
	public enum AdditionMark{none,exclamation};
	public class DialogueCharacter : MonoBehaviour {

		// Use this for initialization
	
		//Animator anim;
		SpriteRenderer spr;
		public List<Sprite> expressions;
		Dictionary<Expression, int> expressionDict;
		void Awake()
		{
			//anim = GetComponent<Animator>();
			spr = GetComponent<SpriteRenderer>();
	
			expressionDict = new Dictionary<Expression, int>();
			expressionDict.Add(Expression.angry,0);
			expressionDict.Add(Expression.ordinary,1);
			expressionDict.Add(Expression.sad,2);
			expressionDict.Add(Expression.shocked,3);
			expressionDict.Add(Expression.smile,4);
			expressionDict.Add(Expression.worried,5);
		}
		void Start () {
			
		}
		
		
	
		Expression expression;
		public Sprite getExpression(Expression expression)
		{
			
			int id = expressionDict[expression];
			return expressions[id];
			//anim.Play(expression);
		}
	}

}
