using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TheEnd;
public class DialogueManager : MonoBehaviour {

	// Use this for initialization
	public TypeWriter typeWriter;
	public TextAsset[] dialogueFiles;
	Dialogue testDialogue;
	DialogueLoader loader;
	Dictionary<string,Dialogue> dialogueDictionary;
	Dictionary<string,DialogueCharacter> characterDict;
    
    public DialoguePanelView dialoguePanel;
	
	public DialogueCharacterPanel chPanel;
    
    public static DialogueManager instance;
	public enum TextFormat{JSON,TXT};
	public TextFormat format;
	void Awake()
	{
		if(instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			throw new UnityException("double singleton");
		}
		
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
        dialoguePanel.Show();
        currentDialogue = dialogue;
		PlayNextLine();
	}
	
	public void PlayNextLine()
	{
		
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
            else
            {
                dialoguePanel.Hide();
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
        chPanel.setCharater(line.chIndex,line.character, line.expression, line.addition);
    }
	
	public void PlayInvestigation(DialogueLine line)
	{
		
	}
	public DialogueCharacter getCharacter(string chName)
	{
		return characterDict[chName];
	}
	// Update is called once per frame
}
