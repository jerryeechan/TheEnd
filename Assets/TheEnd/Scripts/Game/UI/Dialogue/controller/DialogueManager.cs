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
    public DialogueOptionPanel optionPanel;
	public TargetEvent eventTriggerBy = null;
    
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
    bool showOption;
	public void PlayDialogue(string dialogueKey,bool showOption)
	{
        
        this.showOption = showOption;
		print("Playing Dialogue:"+dialogueKey);
		PlayDialogue(dialogueDictionary[dialogueKey]);	
		
	}
	public void PlayDialogue(Dialogue dialogue)
	{
		if(!isDialoguePlaying)
		{
			isDialoguePlaying = true;
			isDialogueFinished = false;
            
            UIManager.instance.hideControlPanel();
			playingType = DialogueLineType.description;
			
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
				print("next line");	
				if(SuperUser.instance.isSkippingDialogues)
				{
					SkipLine();
					PlayNextLine();
				}
			}
            else //end of dialogue
            {
                print(showOption);
                if(showOption)
                {
                    optionPanel.Show();
                    isDialogueFinished = true;
                }
                else
                {
                    hideDialogue();
                }
				
            }

		}
		
	}
    
    public bool isAnimating = false;
	public void hideDialogue()
    {
        if(!isAnimating&&!optionPanel.isAnimating)
        {
            isAnimating = true;
            HideLastPanel();
            linePanel.Hide();
            dialoguePanel.Hide();
            optionPanel.Hide();
            print("hideDialogue");
            Invoke("closed",1);
            isDialogueFinished = true;
            UIManager.instance.showControlPanel();    
        }
        
    }
	void closed()
	{
        print("closed Done");
        print(eventTriggerBy);
        isAnimating = false;
		isDialoguePlaying = false;
		if(eventTriggerBy)
        {
            TargetEvent temp = eventTriggerBy;
            eventTriggerBy = null; 
            temp.SendMessage("Done",SendMessageOptions.DontRequireReceiver);
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
        
//		Debug.Log("character");
		if(playingType != DialogueLineType.character)
		{
			HideLastPanel();
            chPanel.Show();
            print("character panel show");
		}
        chPanel.setCharater(line.chIndex,line.character, line.expression, line.addition,line.special == "memory");
		playingType = DialogueLineType.character;
		
        print("character line");
        
    }
	
	public void PlayInvestigation(DialogueLine line)
	{
		Debug.Log("investigate");
		if(playingType != DialogueLineType.investigate)
		{
            print("show investigate");
			HideLastPanel();
            ivPanel.Show();
		}
        ivPanel.setPicture(line.image);
		playingType = DialogueLineType.investigate;	
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
