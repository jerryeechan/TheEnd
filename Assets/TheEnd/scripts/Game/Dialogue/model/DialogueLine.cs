using UnityEngine;
using System.Collections;
namespace TheEnd{
	
	public enum DialogueLineType{character,description,investigate};
	public class DialogueLine{
		public string text;
		public Expression expression;
		public MainCharacterEnum character;
		public int chIndex;
		public AdditionMark addition;
		public string image;
		
		public DialogueLineType type = DialogueLineType.description;
		public DialogueLine(string text,string character,string expression,int chIndex,string image,string addition)
		{
			this.text = text;
			
			if(character!=null) 
			{
				this.character = (MainCharacterEnum)System.Enum.Parse(typeof(MainCharacterEnum),character);
				type = DialogueLineType.character;
				
				if(expression!=null)
					this.expression = (Expression)System.Enum.Parse(typeof(Expression),expression);
			
				if(addition!=null)
				this.addition = (AdditionMark)System.Enum.Parse(typeof(AdditionMark),addition);
			}
			
			this.chIndex = chIndex;
			
			
			if(image!=null){
				this.image = image;
				type = DialogueLineType.investigate;	
			}
			
			//this.character = 
		}
		
	}
}

