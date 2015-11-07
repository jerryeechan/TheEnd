using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TheEnd;



public class DialogueCharacterManager : MonoBehaviour
{
    
    public static DialogueCharacterManager instance;
    
    public DialogueCharacter moshiue;
    public DialogueCharacter riddle;
    Dictionary<MainCharacterEnum,DialogueCharacter> charDict = new Dictionary<MainCharacterEnum, DialogueCharacter>();
    void Awake()
    {
        instance = this;
        charDict.Add(MainCharacterEnum.moshiue, moshiue);
        charDict.Add(MainCharacterEnum.riddle,riddle);
    }
    public DialogueCharacter getCharacter(MainCharacterEnum ch)
    {
        return charDict[ch];
    }
    
    
}
