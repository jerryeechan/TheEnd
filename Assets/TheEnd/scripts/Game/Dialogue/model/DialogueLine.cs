using UnityEngine;
using System.Collections;

public class DialogueLine{

	public string text;
	public string expression;
	public DialogueCharacter character;
	public DialogueLine(string text,string character,string expression)
	{
		this.text = text;
		this.expression = expression;
		this.character = DialogueManager.instance.getCharacter(character);
		
		//this.character = 
	}
	
	public DialogueLine(string text)
	{
		this.text = text;
	}
	
	public void Play()
	{
		if(character != null)
		{
			character.Play(expression);
		}
	}
	
}
