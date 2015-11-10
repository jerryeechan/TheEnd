using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TheEnd;



public class DialogueCharacterManager : Singleton<DialogueCharacterManager>
{
    
    public DialogueCharacter moshiue;
    public DialogueCharacter riddle;
    public DialogueCharacter ziching;
    Dictionary<MainCharacterEnum,DialogueCharacter> charDict = new Dictionary<MainCharacterEnum, DialogueCharacter>();
    void Awake()
    {
        charDict.Add(MainCharacterEnum.moshiue, moshiue);
        charDict.Add(MainCharacterEnum.riddle,riddle);
        charDict.Add(MainCharacterEnum.ziching,ziching);
    }
    public DialogueCharacter getCharacter(MainCharacterEnum ch)
    {
        if(charDict.ContainsKey(ch))
            return charDict[ch];    
        else
        {
            Debug.LogError("Create and add the Character into DialogueCharacter Manger");
            return null;
        }
            
        
    }
    
    
}
