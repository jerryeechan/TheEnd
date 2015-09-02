using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogue  {

	int id;
	int chapter;
	public TextAsset dialogueJSONFile;
	List<DialogueLine> lines;
	public enum DialogueType{OS,Conversation,Description};
	public DialogueType type;
	public Dialogue(DialogueType type)
	{
		this.type = type;
		lines = new List<DialogueLine>();
	}
	// Use this for initialization
	
	public void addLine(DialogueLine line)
	{
		lines.Add(line);
	}
	
	
	int currentLineIndex = 0;
	public DialogueLine getCurrentLine()
	{
		if(currentLineIndex<lines.Count)
		return lines[currentLineIndex++];
		else
		return null;
	}
	// Update is called once per frame
	
}
