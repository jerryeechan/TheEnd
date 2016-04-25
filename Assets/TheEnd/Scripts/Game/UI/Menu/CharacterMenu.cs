using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TheEnd;
public class CharacterMenu : Singleton<CharacterMenu> {
    public Image chImage;
    public Text chNameText;
       
	// Use this for initialization
    List<MainCharacterEnum> availableCh = new List<MainCharacterEnum>();
    void Awake()
    {
        availableCh.Add(MainCharacterEnum.moshiue);
        availableCh.Add(MainCharacterEnum.shiunyin);
        
        
    }
    public void addCharacter(MainCharacterEnum chEnum){
        availableCh.Add(chEnum);
    }
    int currentID = 0;
	public void SwitchChracter()
    {
        currentID++;
        if(currentID == availableCh.Count)
        currentID = 0;
        
        DialogueCharacter ch = DialogueCharacterManager.instance.getCharacter(availableCh[currentID]);
        chImage.sprite = ch.getExpression(Expression.ordinary);
        chNameText.text = ch.characterName;
        Player.instance.SwitchCharacter(availableCh[currentID]);
    }
}
