using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour {

	// Use this for initialization
	public TypeWriter typeWriter;
	public TextAsset[] dialogueFiles;
	Dialogue testDialogue;
	DialogueLoader loader;
	Dictionary<string,Dialogue> dialogueDictionary;
	Dictionary<string,DialogueCharacter> characterDict;

    public DialogueCharaterPanel chPanel1;
    public DialogueCharaterPanel chPanel2;
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
		test();
		
	}
	/**
	my test	
	
	**/
	
	void test()
	{	
		if(dialogueFiles.Length>0)
			PlayDialogue(loader.LoadDialoguesText(dialogueFiles[0]));
	}
	
	List<Dialogue> dialogues;
	public void loadDialogue(int chapter)
	{
		dialogueDictionary = loader.LoadDialoguesJSON(dialogueFiles[chapter]);
	}
	
	Dialogue currentDialogue;
	public void PlayDialogue(string dialogueKey)
	{
		PlayDialogue(dialogueDictionary[dialogueKey]);
	}
	public void PlayDialogue(Dialogue dialogue)
	{
		currentDialogue = dialogue;
		PlayNextLine();
	}
	
	public void PlayNextLine()
	{
		if(typeWriter.isPlaying == true)
		{
			typeWriter.Skip();
		}
		else
		{
			DialogueLine line = currentDialogue.getCurrentLine();
			if(line!=null)
			{
				line.Play();
				typeWriter.Play(line.text);
				print("next line");
			}

		}
		
	}
	public void SkipLine()
	{
		typeWriter.Skip();
	}
	
	public void PlayCharacterExpression(int chIndex,string character, string expression)
    {
        chPanel1.setCharater(character, expression);
    }
	public DialogueCharacter getCharacter(string chName)
	{
		return characterDict[chName];
	}
	// Update is called once per frame
}
