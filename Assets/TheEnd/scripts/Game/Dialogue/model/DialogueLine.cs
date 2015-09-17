using UnityEngine;
using System.Collections;
using TheEnd;
public class DialogueLine{

	public string text;
	public string expression;
	public string character;
    public int chIndex;
	public DialogueLine(string text,string character,string expression,int chIndex)
	{
		this.text = text;
		this.expression = expression;
        this.character = character;
        this.chIndex = chIndex;
		//this.character = 
	}
	
	public DialogueLine(string text)
	{
		this.text = text;
	}
	
	public void Play()
	{
        //DialogueManager.instance.
        
	}
	
}
