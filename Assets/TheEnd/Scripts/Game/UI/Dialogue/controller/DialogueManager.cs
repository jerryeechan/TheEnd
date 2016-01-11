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
    public DialogueLinePanel linePanel;
	public PlayDialogueEvent eventTriggerBy = null;
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
		print("Playing Dialogue:"+dialogueKey);
		PlayDialogue(dialogueDictionary[dialogueKey]);	
		
	}
	public void PlayDialogue(Dialogue dialogue)
	{
		if(!isDialoguePlaying)
		{
			isDialoguePlaying = true;
			isDialogueFinished = false;
	        Player.instance.lockMove();
			playingType = DialogueLineType.description;
			Debug.Log("dialogue show");
			dialoguePanel.Show();
            linePanel.Show();
			currentDialogue = dialogue;
			PlayNextLine();
		}
		else{
			PlayNextLine();
		}
	}
	
	DialogueLineType playingType = DialogueLineType.description;
	public bool isDialoguePlaying = false;
	bool isDialogueFinished = true;
	
	public void PlayNextLine()
	{
		if(isDialogueFinished == true)
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
				HideLastPanel();
                linePanel.Hide();
                dialoguePanel.Hide();
				Player.instance.unlockMove();
				Invoke("closed",1);
				isDialogueFinished = true;
            }

		}
		
	}
	
	void closed()
	{
		isDialoguePlaying = false;
		if(eventTriggerBy)
		eventTriggerBy.SendMessage("Done",SendMessageOptions.DontRequireReceiver);
		eventTriggerBy = null;
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
//		Debug.Log("character");
		if(playingType != DialogueLineType.character)
		{
			HideLastPanel();
            chPanel.Show();
            print("character panel show");
		}
		playingType = DialogueLineType.character;
		
        print("character line");
        chPanel.setCharater(line.chIndex,line.character, line.expression, line.addition,line.special == "memory");
    }
	
	public void PlayInvestigation(DialogueLine line)
	{
		Debug.Log("investigate");
		if(playingType != DialogueLineType.investigate)
		{
			HideLastPanel();
            ivPanel.Show();
		}
		playingType = DialogueLineType.investigate;
		ivPanel.setPicture(line.image);
		
	}
	public DialogueCharacter getCharacter(string chName)
	{
		return characterDict[chName];
	}
	public void HideLastPanel()
	{
		Debug.Log("hide last panel");
		Debug.Log(playingType);
		switch(playingType)
		{
			case DialogueLineType.character:
				chPanel.Hide();
				Debug.Log("hide ch panel");
			break;
			case DialogueLineType.investigate:
				ivPanel.Hide();
				Debug.Log("hide iv panel");
			break;
		}
		
	}
	// Update is called once per frame
}
