using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using TheEnd;
public class DialogueLoader  {

	public DialogueLoader()
	{

	}
	/*
	public Dialogue LoadDialoguesText(TextAsset file)
	{
		string[] lines = file.text.Split('\n');
		Debug.Log("DialogueLoader:"+lines.Length);
		Dialogue dialogue = new Dialogue(Dialogue.DialogueType.description);
		foreach(string line in lines)
		{
			dialogue.addLine(new DialogueLine(line));
		}
		return dialogue;
	}*/
	public Dictionary<string,Dialogue> LoadDialoguesJSON(TextAsset file)
	{
		Dictionary<string,Dialogue> dict = new Dictionary<string, Dialogue>();

		JSONNode chapter = JSON.Parse(file.text);
		JSONArray dialoguesJSON = chapter["dialogues"].AsArray;

		foreach(JSONNode dialogueJSON in dialoguesJSON)
		{
			Dialogue newDialogue = new Dialogue();
//			Debug.Log(dialogueJSON);
			parseLines(newDialogue,dialogueJSON["lines"].AsArray);
			dict.Add(dialogueJSON["id"],newDialogue);
		}
		return dict;
	}

	void parseLines(Dialogue dialogue,JSONArray linesJSON)
	{
		foreach(JSONNode lineJSON in linesJSON)
		{
			dialogue.addLine(new DialogueLine(lineJSON["line"],lineJSON["character"], lineJSON["expression"], lineJSON["index"].AsInt,lineJSON["image"], lineJSON["addition"],lineJSON["special"]));
		}
		
			/*
			
			if(linesJSON)
				foreach(JSONNode lineJSON in linesJSON)
				{
					Debug.Log(lineJSON["additional"]);

					
				}
			
		*/

	}

	void readFile(TextAsset file)
	{
		//linetexts = ( textFile.text.Split( '\n' ) );

	}

}
