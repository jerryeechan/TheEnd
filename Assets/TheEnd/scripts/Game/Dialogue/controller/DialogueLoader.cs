using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
public class DialogueLoader  {

	public DialogueLoader()
	{
	
	}
	
	public Dialogue LoadDialoguesText(TextAsset file)
	{
		string[] lines = file.text.Split('\n');
		Debug.Log("DialogueLoader:"+lines.Length);	
		Dialogue dialogue = new Dialogue(Dialogue.DialogueType.Description);
		foreach(string line in lines)
		{
			dialogue.addLine(new DialogueLine(line));
		}
		return dialogue;
	}
	public Dictionary<string,Dialogue> LoadDialoguesJSON(TextAsset file)
	{
		Dictionary<string,Dialogue> dict = new Dictionary<string, Dialogue>();
		
		JSONNode chapter = JSON.Parse(file.text);
		JSONArray dialoguesJSON = chapter["dialogues"].AsArray;
		
		foreach(JSONNode dialogueJSON in dialoguesJSON)
		{
			Dialogue newDialogue = new Dialogue((Dialogue.DialogueType)System.Enum.Parse(typeof(Dialogue.DialogueType),dialogueJSON["type"].Value));
			
			
			parseLines(newDialogue,dialogueJSON["lines"].AsArray);
			dict.Add(dialogueJSON["id"],newDialogue);
		}
		return dict;
	}
	
	void parseLines(Dialogue dialogue,JSONArray linesJSON)
	{
		switch(dialogue.type)
		{
			case Dialogue.DialogueType.Conversation:
			foreach(JSONNode lineJSON in linesJSON)
			{
				dialogue.addLine(new DialogueLine(lineJSON["line"],lineJSON["character"],lineJSON["expression"]));
			}
			break;
			
			case Dialogue.DialogueType.Description:
			foreach(JSONNode lineJSON in linesJSON)
			{
				dialogue.addLine(new DialogueLine(lineJSON["line"]));
			}
			break;
		}
		
	}
	
	void readFile(TextAsset file)
	{
		//linetexts = ( textFile.text.Split( '\n' ) );
		
	}
	
}
