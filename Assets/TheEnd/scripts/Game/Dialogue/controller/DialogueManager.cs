using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TheEnd;
public class DialogueManager : Singleton<DialogueManager> {

	// Use this for initialization
	public TypeWriter typeWriter;
	public TextAsset[] dialogueFiles;
	Dialogue testDialogue;
	DialogueLoader loader;
	Dictionary<string,Dialogue> dialogueDictionary;
	Dictionary<string,DialogueCharacter> characterDict;
    
    public DialoguePanelView dialoguePanel;
	
	public DialogueCharacterPanel chPanel;
	public DialogueInvestigationPanel ivPanel;
    
	
	public enum TextFormat{JSON,TXT};
	public TextFormat format;
	void Awake()
	{
		
		dialogueDictionary = new Dictionary<string, Dialogue>();
		characterDict = new Dictionary<string, DialogueCharacter>();
		loader = new DialogueLoader();

        //initCharacterDict();	
        loadDialogue(1);
		
	}
	/**
	my test	
	
	**/
	
	
	List<Dialogue> dialogues;
	public void loadDialogue(int chapter)
	{
		dialogueDictionary = loader.LoadDialoguesJSON(dialogueFiles[chapter-1]);
	}
	
	Dialogue currentDialogue;
	public void PlayDialogue(string dialogueKey)
	{
		PlayDialogue(dialogueDictionary[dialogueKey]);
	}
	public void PlayDialogue(Dialogue dialogue)
	{
		isDialogueOver = false;
		playingType = DialogueLineType.description;
        dialoguePanel.Show();
        currentDialogue = dialogue;
		PlayNextLine();
	}
	
	DialogueLineType playingType = DialogueLineType.description;
	bool isDialogueOver = false;
	public void PlayNextLine()
	{
		if(isDialogueOver == true)
		return;
		if(typeWriter.isPlaying == true)
		{
			SkipLine();
		}
		else
		{
			
			DialogueLine line = currentDialogue.getCurrentLine();
			
			if(line!=null)
			{
				switch(line.type)
				{
					case DialogueLineType.character:
						PlayCharacterExpression(line);
						break;
					case DialogueLineType.investigate:
						PlayInvestigation(line);
						break;
					case DialogueLineType.description:
						PlayDescription(line);
						break;
				}
				
				
				
				typeWriter.Play(line.text);
//				print("next line");	
				if(SuperUser.instance.isSkippingDialogues)
				{
					SkipLine();
					PlayNextLine();
				}
				
			}
            else //end of dialogue
            {
				//chPanel.Hide();
                
				//ivPanel.Hide();
				HideLastPanel();
				dialoguePanel.Hide();
				isDialogueOver = true;
            }

		}
		
	}
	public void SkipLine()
	{
		typeWriter.Skip();
	}
	
	public void PlayDescription(DialogueLine line)
	{
		
	}
	public void PlayCharacterExpression(DialogueLine line)
    {
		Debug.Log("character");
		if(playingType != DialogueLineType.character)
		{
			HideLastPanel();
		}
		playingType = DialogueLineType.character;
		chPanel.Show();
        chPanel.setCharater(line.chIndex,line.character, line.expression, line.addition);
    }
	
	public void PlayInvestigation(DialogueLine line)
	{
		Debug.Log("investigate");
		if(playingType != DialogueLineType.investigate)
		{
			HideLastPanel();
		}
		playingType = DialogueLineType.investigate;
		ivPanel.Show();
		ivPanel.setPicture(line.image);
		
	}
	public DialogueCharacter getCharacter(string chName)
	{
		return characterDict[chName];
	}
	public void HideLastPanel()
	{
		switch(playingType)
		{
			case DialogueLineType.character:
				chPanel.Hide();
			break;
			case DialogueLineType.investigate:
				ivPanel.Hide();
			break;
		}
		
	}
	// Update is called once per frame
}
